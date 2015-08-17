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

			LocalPerformanceTest ();

		}	


		static void WaitForInput ()
		{
			//0;
			int sizeOfLength = 4;
			int readLength = 0;
			using (Stream stdin = Console.OpenStandardInput (), stdout = Console.OpenStandardOutput ()) {
				int sizeOfData = 20256;
				byte[] fullDataBuffer = new byte[sizeOfData];
				//new byte[19804];//
				int bytes;
				int readData = 0;
				while (true) {
					bytes = stdin.Read (fullDataBuffer, readData, sizeOfData - readData);
					readData += bytes;
					if (readData == sizeOfData) {
						var byteBuffer = new FlatBuffers.ByteBuffer (bytes);
						var gamestate = GameStateRoot.GetRootAsGameStateRoot (byteBuffer);
						FBDeserializationService.singleton.Deserialize (gamestate);
						createSomeGroups ();
						
						FBSerialisationService.singleton.corePool = FBDeserializationService.singleton.corePool;
						FBSerialisationService.singleton.metaPool = FBDeserializationService.singleton.metaPool;
						
						var outData = FBSerialisationService.singleton.GenerateGameState ();
						stdout.Write(outData, 0, outData.Length);
					}
				}


			}
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
