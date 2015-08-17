%%%----------------------------------------------------------------------
%%% File    : echo.erl
%%% Author  : Pete Kazmier <pete-trapexit@kazmier.com>
%%% Purpose : Port Tutorial
%%% Created : Fri Jan 13 12:39:27 EST 2006
%%%----------------------------------------------------------------------

-module(echo).
-author('pete-trapexit@kazmier.com').

-behavior(gen_server).

%% External exports
-export([start_link/1]).

%% API functions
-export([start_pool/1, echo/1, echo/2, benchmark/3]).

%% gen_server callbacks
-compile([export_all]).

%% Server state
-record(state, {port}).

%%%----------------------------------------------------------------------
%%% API
%%%----------------------------------------------------------------------

benchmark(PoolSize, PayloadLength, Samples, Parallel) ->
  start_pool(PoolSize),
  {{Samples, PayloadLength, Parallel}, Ops, DataRate} = benchmark(PayloadLength, Samples, Parallel),
  {{PoolSize, PayloadLength, Samples, Parallel}, Ops, DataRate}.

benchmark(PayloadLength, Samples, Parallel) ->
    % Payload1 = << <<"x">> || _ <- lists:seq(1, PayloadLength - 1) >>,
    % Payload2 = << Payload1/binary, <<"\n">>/binary >>,
    % {ok, Json} = file:read_file("quests.json"),
    {ok, Binary} = file:read_file("player_state.mon"),

    Payload = Binary,

    {Elapsed, _} =
    fixed_rate:run_parallel(Parallel,
        fun(_) ->
            echo:echo(Payload),
            ok
        end,
    lists:seq(1, Samples), 1000000),
    {{Samples, PayloadLength, Parallel}, Samples/Elapsed, byte_size(Payload) * Samples / Elapsed}.

benchmark_nif(Samples, Parallel) ->
    {ok, Json} = file:read_file("quests.json"),
    {ok, Schema} = file:read_file("quests.fbs"),

    {Elapsed, _} =
    fixed_rate:run_parallel(Parallel,
        fun(_) ->
            fb_nif:json_to_fb(Json, Schema),
            ok
        end,
    lists:seq(1, Samples), 1000000),
    {{Samples, Parallel}, Samples/Elapsed, size(Json) * Samples / Elapsed}.

benchmark_json(Samples, Parallel) ->
    {ok, Json} = file:read_file("quests.json"),
    {ok, Schema} = file:read_file("quests.fbs"),

    {Elapsed, _} =
    fixed_rate:run_parallel(Parallel,
        fun(_) ->
            jiffy:decode(Json, [return_maps]),
            ok
        end,
    lists:seq(1, Samples), 1000000),
    {{Samples, Parallel}, Samples/Elapsed, size(Json) * Samples / Elapsed}.


start_pool(Size) ->
    application:load(echo),
    application:stop(palma),
    palma:start(),
    palma:new(echo_pool, Size, {echo, {echo, start_link, ["./run.sh"]}, permanent, 1000, worker, [echo]}).

start_link(ExtProg) ->
    gen_server:start_link(echo, ExtProg, []).

echo(Msg) ->
    % echo(<< 0:8, Msg/binary >>, palma:pid(echo_pool)).
    echo(Msg, palma:pid(echo_pool)).

echo(Msg, Server) ->
    gen_server:call(Server, {echo, Msg}, get_timeout()).



%%%----------------------------------------------------------------------
%%% Callback functions from gen_server
%%%----------------------------------------------------------------------

init(ExtProg) ->
    process_flag(trap_exit, true),
    Port = open_port({spawn, ExtProg}, [binary, {packet, 4}, {parallelism, true}]),
    {ok, #state{port = Port}}.

handle_call({echo, Msg}, _From, #state{port = Port} = State) ->
    port_command(Port, Msg),
    case collect_response(Port) of
        {response, Response} ->
            {reply, Response, State};
        timeout ->
            {stop, port_timeout, State};
        Else ->
            {reply, Else, State}
    end.

handle_cast(_Msg, State) ->
    {noreply, State}.

handle_info({'EXIT', Port, Reason}, #state{port = Port} = State) ->
    {stop, {port_terminated, Reason}, State};

handle_info({Port, {data, Data}}, State) ->
    io:fwrite("EXTRA:"),
    % io:fwrite(Data),
    {noreply, State}.

code_change(_OldVsn, State, _Extra) ->
    {ok, State}.

terminate({port_terminated, _Reason}, _State) ->
    ok;
terminate(_Reason, #state{port = Port} = _State) ->
    port_close(Port).

%%%----------------------------------------------------------------------
%%% Internal functions
%%%----------------------------------------------------------------------

get_timeout() ->
    {ok, Value} = application:get_env(echo, timeout),
    Value.

get_maxline() ->
    {ok, Value} = application:get_env(echo, maxline),
    Value.

collect_response(Port) ->
    receive
        {Port, {data, Data}} ->
            % io:format("size: ~p\n", [byte_size(Data)]),
            % io:fwrite(Data),
            % file:write_file("quests.bin.lz4", Data),
            {response, Data}
    %% Prevent the gen_server from hanging indefinitely in case the
    %% spawned process is taking too long processing the request.
    after 3000 ->
            timeout
    end.
