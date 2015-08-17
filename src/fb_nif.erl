-module(fb_nif).
-export([json_to_fb/2,init/0]).
-on_load(init/0).

init() ->
    ok = erlang:load_nif("./priv/fb_wrap/fb_nif", 0).

json_to_fb(_json, _schema) ->
    exit(nif_library_not_loaded).