using System;
using NetJSON;
using lz4;
using System.IO;

namespace workerTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
//			string mode = "";
//			if (args.Length > 0) {
//				mode = args[0];
//			}

			System.IO.BinaryReader stdin  = new System.IO.BinaryReader(Console.OpenStandardInput());
			System.IO.Stream stdout = Console.OpenStandardOutput();
//			Stream stdin = Console.OpenStandardInput ();

//			byte[] size = new byte[4];
//
//			while (true) {
//				int sizeRead = 0;
//				while (true) {
//					int dataRead = stdin.Read (size, sizeRead, size.Length - sizeRead); 
//
//					if (dataRead == 0) {
//						return;
//					}
//					sizeRead += dataRead;
//					if (sizeRead == 4) {
//						break;
//					}
//				}
//				Array.Reverse (size);
//				int size_int = BitConverter.ToInt32 (size, 0);
//
//				byte[] properData = new byte[size_int];
//				int properDataRead = 0;
//				while (true) {
//					int dataRead = stdin.Read (properData, properDataRead, properData.Length - properDataRead); 
//					properDataRead += dataRead;
//					if (properDataRead == size_int) {
//						break;
//					}
//				}
//				
//				Array.Reverse (size);
//				stdout.Write (size, 0, 4);
//				stdout.Write (properData, 0, size_int);
//				stdout.Flush ();
//			}
//
//
//			byte[] test = BitConverter.GetBytes(132123321321);
//			byte[] compressed2 = Lz4Net.Lz4.CompressBytes (test);
//			stdout.Write (compressed2, 0, compressed2.Length);

//			byte[] test = BitConverter.GetBytes(1321233213);
//			byte[] compressed2 = lz4.LZ4Helper.Compress (test);
//			stdout.Write (compressed2, 0, compressed2.Length);


			while (true) {
				byte[] size = stdin.ReadBytes(4);

				if (size.Length > 0) {
					Array.Reverse (size);
					int size_int = BitConverter.ToInt32 (size, 0);

					byte[] data = stdin.ReadBytes (size_int);

//					Array.Reverse (size);
					//				Console.Error.Write("SIZE: " + BitConverter.ToString(size));
//					stdout.Write (size, 0, 4);

//					byte[] bin_size = BitConverter.GetBytes (compressed_size);
					Array.Reverse (size);
					stdout.Write (size, 0, 4);
					stdout.Write (data, 0, size_int);
					stdout.Flush ();
				} else {
					break;
				}
			}

//			var 
//			while ((line = Console.ReadLine()) != null) {				    			
//				if (mode == "json") {
//					var json = NetJSON.NetJSON.DeserializeObject (line);
//					Console.Out.WriteLine (NetJSON.NetJSON.Serialize (json));								
//				} else if(mode == "lz4") {
//					lz4.LZ4Helper.Compress(
//				
//				} else {
//					Console.Out.WriteLine(line);				
//				}
//				Console.Out.Flush();		
//			}
		}
	}
}
