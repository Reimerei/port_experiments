#include <iostream>

#include "flatbuffers/flatbuffers.h"
#include "flatbuffers/idl.h"
#include "flatbuffers/util.h"
#include "flatbuffers/reflection.h"
#include "flatbuffers/reflection_generated.h"

#include "nifpp.h"

using namespace std;

class Parser_Wrapper {

  public:
  void * bin[4];
  int size;

  flatbuffers::Parser parser;

  Parser_Wrapper(char * json, char * schema) {
    parser.Parse(schema);    
    parser.Parse(json);

    size = 4;
    //parser.builder_.GetSize();
    // bin = parser.builder_.GetBufferPointer();
  }

   ~Parser_Wrapper() {
    parser.builder_.Clear();
   }

   void * get_bin() {
    return bin;
   }

   int get_size() {
    return size;
   }

};

extern "C" {

  static int load(ErlNifEnv* env, void** priv, ERL_NIF_TERM load_info)
  {
    nifpp::register_resource<Parser_Wrapper>(env, nullptr, "fb_bin");
    return 0;
  }

  static ERL_NIF_TERM json_to_fb_nif(ErlNifEnv* env, int argc, const ERL_NIF_TERM argv[])
  {
    // load schema
    // string schemafile;
    // string jsonfile;
    // flatbuffers::LoadFile("/tmp/quests.fbs", false, &schemafile);

    // flatbuffers::Parser parser;

    try
    {
      auto fb_bin = nifpp::construct_resource<Parser_Wrapper>( nifpp::get<char *>(env, argv[0]), nifpp::get<char *>(env, argv[1]));
      return nifpp::make_resource_binary(env, fb_bin, (const void *)(fb_bin->get_bin()), fb_bin->get_size());

      // bool res1 = parser.Parse(schemafile.c_str());    
      // bool res2 = parser.Parse(json.c_str());


      // cout << "JSON: " << json << endl ;
      // cout << "SIZE: " << bin_size << endl ;
      // cout << "RES1: " << res1 << endl ;
      // cout << "RES2: " << res2 << endl ;


      // nifpp::TERM term = nifpp::make(env, ebin);
      // return term;
    }
    catch(nifpp::badarg) {}
    catch(std::ios_base::failure) {}
    return enif_make_badarg(env);
  }

  static ErlNifFunc nif_funcs[] = { {"json_to_fb", 2, json_to_fb_nif} };

  ERL_NIF_INIT(fb_nif, nif_funcs, load, NULL, NULL, NULL)
}

