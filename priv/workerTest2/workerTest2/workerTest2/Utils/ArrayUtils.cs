using System.Text;
using System;

public static class ArrayUtils 
{	
	public static bool[] ConvertToBool<T>(T[] items, T falseItem)
	{
		bool[] output = new bool[items.Length];
		
		for(int i=items.Length-1; i>=0; i--){
			output[i] = !items[i].Equals(falseItem);
		}
		return output;
	}

	public static bool[,] ConvertToBool<T>(T[,] items, T falseItem)
	{
		bool[,] output = new bool[items.GetLength(0), items.GetLength(1)];
		
		for(int i=items.GetLength(0)-1; i>=0; i--){
			for(int j=items.GetLength(1)-1; j>=0; j--){
				output[i,j] = !items[i,j].Equals(falseItem);
			}
		}
		return output;
	}

//	public static string GenerateString<T>(T[] items)
//	{
//		StringBuilder output = new StringBuilder();
//		
//		bool first = true;
//		foreach(T item in items){
//			if(item == null){
//				continue;
//			}
//			if(!first){
//				output.Append(",");
//			}
//			output.Append(SerialisationUtils.GenerateLine(item));
//			first = false;
//		}
//		return output.ToString();
//	}
}

public static class ArrayExtensions
{
	public static bool[] ConvertToBool<T>(this T[] ts, T falseItem)
	{
		return ArrayUtils.ConvertToBool(ts, falseItem);
	}

	public static bool[,] ConvertToBool<T>(this T[,] ts, T falseItem)
	{
		return ArrayUtils.ConvertToBool(ts, falseItem);
	}

	public static T[] Copy<T>(this T[] ts)
	{
		T[] newTs = new T[ts.Length];
		ts.CopyTo(newTs, 0);
		
		return newTs;
	}

	public static T[,] Copy<T>(this T[,] ts)
	{
		T[,] newTs = new T[ts.GetLength(0), ts.GetLength(1)];
		for(int i=ts.GetLength(0)-1; i>=0; i--){
			for(int j=ts.GetLength(1)-1; j>=0; j--){
				newTs[i,j] = ts[i,j];
			}
		}

		return newTs;
	}
	
//	public static string Serialise<T>(this T[] ts)
//	{
//		return ArrayUtils.GenerateString(ts);
//	}
}