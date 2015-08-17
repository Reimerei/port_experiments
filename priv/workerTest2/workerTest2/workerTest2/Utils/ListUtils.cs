using System.Collections.Generic;

public static class ListUtils 
{	
//	public static string GenerateString<T>(List<T> items)
//	{
//		return ArrayUtils.GenerateString(items.ToArray());
//	}
}

public static class ListExtensions
{
	public static List<T> Copy<T>(this List<T> list)
	{
		return new List<T>(list);
	}

//	public static string Serialise<T>(this List<T> ts)
//	{
//		return ListUtils.GenerateString(ts);
//	}
}