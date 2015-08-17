using System.Text;
using System.Collections.Generic;

public static class SetUtils 
{	
//	public static string GenerateString<T>(HashSet<T> items, bool withQuotes = true, string separator = ",")
//	{
//		StringBuilder output = new StringBuilder();
//		
//		bool first = true;
//		foreach(T item in items){
//			if(item == null){
//				continue;
//			}
//			if(!first){
//				output.Append(separator);
//			}
//			output.Append(SerialisationUtils.GenerateLine(item, withQuotes));
//			first = false;
//		}
//		return output.ToString();
//	}
}

public static class SetExtensions
{
	public static HashSet<T> Copy<T>(this HashSet<T> ts)
	{
		return new HashSet<T>(ts);
	}
		
//	public static string Serialise<T>(this HashSet<T> ts, bool withQuotes = true, string separator = ",")
//	{
//		return SetUtils.GenerateString(ts, withQuotes, separator);
//	}

	public static T[] ToArray<T>(this HashSet<T> ts)
	{
		T[] array = new T[ts.Count];
		ts.CopyTo(array);

		return array;
	}

	public static List<T> ToList<T>(this HashSet<T> ts)
	{
		return new List<T>(ts.ToArray());
	}
}