using System;
using System.IO;
using SimpleJSON;

public class WorkerTestScript
{ 
	static void Main(string[] args)
	{		
		string mode = "";
		if (args.Length > 0) {
			mode = args[0];
		}

		// StreamWriter sw = new StreamWriter(Console.OpenStandardOutput());
  //   sw.AutoFlush = false;

		string line;
		while ((line = Console.ReadLine()) != null) {				    			
			if (mode == "json") {
				JSONNode json = JSON.Parse(line);
				Console.Out.WriteLine(json.ToString());								
			} else {
				Console.Out.WriteLine(line);				
			}
			Console.Out.Flush();		
		}
	}
	
	// static void Main2Zipped(string[] args)
	// {
	// 	string line = Console.ReadLine();

	// 	string unzipped = UnZip(line);


	// 	string zipped = Zip(json.ToString());
		
	// 	Console.WriteLine(zipped);
	// }
	
	// public static string Zip(string value)
	// {
	// 	//Transform string into byte[]  
	// 	byte[] byteArray = new byte[value.Length];
	// 	int indexBA = 0;
	// 	foreach (char item in value.ToCharArray())
	// 	{
	// 		byteArray[indexBA++] = (byte)item;
	// 	}
		
	// 	//Prepare for compress
	// 	System.IO.MemoryStream ms = new System.IO.MemoryStream();
	// 	System.IO.Compression.GZipStream sw = new System.IO.Compression.GZipStream(ms, System.IO.Compression.CompressionMode.Compress);
		
	// 	//Compress
	// 	sw.Write(byteArray, 0, byteArray.Length);
	// 	//Close, DO NOT FLUSH cause bytes will go missing...
	// 	sw.Close();
		
	// 	//Transform byte[] zip data to string
	// 	byteArray = ms.ToArray();
	// 	System.Text.StringBuilder sB = new System.Text.StringBuilder(byteArray.Length);
	// 	foreach (byte item in byteArray)
	// 	{
	// 		sB.Append((char)item);
	// 	}
	// 	ms.Close();
	// 	sw.Dispose();
	// 	ms.Dispose();
	// 	return sB.ToString();
	// }
	
	// public static string UnZip(string value)
	// {
	// 	//Transform string into byte[]
	// 	byte[] byteArray = new byte[value.Length];
	// 	int indexBA = 0;
	// 	foreach (char item in value.ToCharArray())
	// 	{
	// 		byteArray[indexBA++] = (byte)item;
	// 	}
		
	// 	//Prepare for decompress
	// 	System.IO.MemoryStream ms = new System.IO.MemoryStream(byteArray);
	// 	System.IO.Compression.GZipStream sr = new System.IO.Compression.GZipStream(ms,
	// 	                                                                           System.IO.Compression.CompressionMode.Decompress);
		
	// 	//Reset variable to collect uncompressed result
	// 	byteArray = new byte[byteArray.Length];
		
	// 	//Decompress
	// 	int rByte = sr.Read(byteArray, 0, byteArray.Length);
		
	// 	//Transform byte[] unzip data to string
	// 	System.Text.StringBuilder sB = new System.Text.StringBuilder(rByte);
	// 	//Read the number of bytes GZipStream red and do not a for each bytes in
	// 	//resultByteArray;
	// 	for (int i = 0; i < rByte; i++)
	// 	{
	// 		sB.Append((char)byteArray[i]);
	// 	}
	// 	sr.Close();
	// 	ms.Close();
	// 	sr.Dispose();
	// 	ms.Dispose();
	// 	return sB.ToString();
	// }
}