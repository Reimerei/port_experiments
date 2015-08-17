using System;
using DogeFB;
using System.Diagnostics;
using Entitas;
using FlatBuffers;
using System.IO;

namespace PlayerStateConverter
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			WaitForInput ();
		}	


		static void WaitForInput ()
		{

			System.IO.BinaryReader stdin  = new System.IO.BinaryReader(Console.OpenStandardInput());
			System.IO.Stream stdout = Console.OpenStandardOutput();

			Console.Error.WriteLine ("Start!");

			while (true) {
				byte[] input_size = stdin.ReadBytes(4);

				if (input_size.Length == 4) {
					// Read data from stdin
					Array.Reverse (input_size);
					int input_size_int = BitConverter.ToInt32 (input_size, 0);

//					Console.Error.WriteLine ("input size: " + input_size_int);
					byte[] input_data = stdin.ReadBytes (input_size_int);

					// run commands
					byte[] output_data = runTest (input_data);
//					byte[] output_data = input_data;

					// write data to stdout
					int output_size_int = output_data.Length;
					byte[] output_size = BitConverter.GetBytes (output_size_int);
					Array.Reverse (output_size);
					stdout.Write (output_size, 0, 4);
					stdout.Write (output_data, 0, output_size_int);
					stdout.Flush ();
				} else {
					break;
				}
			}
		}

		static byte[] runTest(byte[] data) {
			var byteBuffer = new FlatBuffers.ByteBuffer (data);
			var gamestate = GameStateRoot.GetRootAsGameStateRoot (byteBuffer);
			FBDeserializationService.singleton.Deserialize (gamestate);
			createSomeGroups ();
//
			FBSerialisationService.singleton.corePool = FBDeserializationService.singleton.corePool;
			FBSerialisationService.singleton.metaPool = FBDeserializationService.singleton.metaPool;
//
			FBSerialisationService.singleton.GenerateGameState ();
//
			return data;
		}

		static void LocalPerformanceTest ()
		{
			byte[] data = System.IO.File.ReadAllBytes ("/Users/mzaks/Downloads/flatbuffers-master/samples/doge/gen/player_state.mon");
			int length1 = data.Length, length2 = 0;
			var byteBuffer = new FlatBuffers.ByteBuffer (data);
			var gamestate = GameStateRoot.GetRootAsGameStateRoot (byteBuffer);
			Stopwatch watch = new Stopwatch ();
			int numberOfRuns = 100;
			double[] m = new double[numberOfRuns];
			for (int i = 0; i < numberOfRuns; i++) {
				watch.Start ();
				FBDeserializationService.singleton.Deserialize (gamestate);
				createSomeGroups ();

				FBSerialisationService.singleton.corePool = FBDeserializationService.singleton.corePool;
				FBSerialisationService.singleton.metaPool = FBDeserializationService.singleton.metaPool;

				data = FBSerialisationService.singleton.GenerateGameState ();
				length2 = data.Length;
				byteBuffer = new FlatBuffers.ByteBuffer (data);
				gamestate = GameStateRoot.GetRootAsGameStateRoot (byteBuffer);
				watch.Stop ();
				m [i] = watch.Elapsed.TotalMilliseconds;
			}
			Console.WriteLine ("Hello World! " + gamestate.GameData1.PlayerName);
			for (int i = 0; i < numberOfRuns; i++) {
				Console.WriteLine ("Elapsed " + ((i == 0) ? m [i] : m [i] - m [i - 1]));
			}
			Console.WriteLine ("Elapsed AVG " + ((m [numberOfRuns - 1] - m [0]) / (numberOfRuns - 1)));
			Console.WriteLine ("Number of core pool entities " + FBDeserializationService.singleton.corePool.Count);
			Console.WriteLine ("Number of meta pool entities " + FBDeserializationService.singleton.metaPool.Count);
			Console.WriteLine ("Length before: " + length1 + " after: " + length2);
			System.IO.File.WriteAllBytes (@"/Users/mzaks/Downloads/flatbuffers-master/samples/doge/gen/player_state2.mon", data);
		}

		static void createSomeGroups()
		{
			FBSerialisationService.singleton.corePool.GetGroup(CoreGameMatcher.Building);
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Position));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Academy));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Crafter));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Size));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Position, CoreGameMatcher.Ship));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Position, CoreGameMatcher.Townhall));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Building, CoreGameMatcher.Position, CoreGameMatcher.Arsenal));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Island, CoreGameMatcher.Production, CoreGameMatcher.IslandOwner));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Island, CoreGameMatcher.IslandOwner));
			FBSerialisationService.singleton.corePool.GetGroup(Matcher.AllOf(CoreGameMatcher.Island, CoreGameMatcher.Production));
		}
	}

}
