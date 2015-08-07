using System;
using NetJSON;

namespace workerTest
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			string mode = "";
			if (args.Length > 0) {
				mode = args[0];
			}

			string line;
			while ((line = Console.ReadLine()) != null) {				    			
				if (mode == "json") {
					var json = NetJSON.NetJSON.DeserializeObject(line);
					Console.Out.WriteLine(NetJSON.NetJSON.Serialize(json));								
				} else {
					Console.Out.WriteLine(line);				
				}
				Console.Out.Flush();		
			}
		}
	}
}
