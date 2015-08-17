using System.Collections.Generic;
using System.Text;

public static class DictUtils 
{	
	#region Public API

//	public static string GenerateDictionaryString<T>(Dictionary<string,T> items, bool forUI = false, string separator = ",")
//	{
//		StringBuilder output = new StringBuilder();
//		
//		bool first = true;
//		foreach(string item in items.Keys)
//		{
//			if(items[item] == null){
//				continue;
//			}
//			if(!first){
//				output.Append(separator);
//			}
//			output.Append(SerialisationUtils.GenerateDictionaryLine<T>(item, items[item], forUI));
//			first = false;
//		}
//		return output.ToString();
//	}

	#endregion
}

public static class DictExtensions
{
	public static int TotalCount(this Dictionary<string,int> dict)
	{
		int count = 0;

		foreach(string key in dict.Keys){
			count += dict[key];
		}

		return count;
	}
		
	public static Dictionary<string, int> Add(this Dictionary<string, int> dict, Dictionary<string, int> toAdd)
	{
		foreach(string key in toAdd.Keys){
			if(dict.ContainsKey(key)){
				dict[key] += toAdd[key];
			}else{
				dict.Add(key, toAdd[key]);
			}
		}
		return dict;
	}

	public static Dictionary<string,int> Multiply(this Dictionary<string,int> dict, float multiplier)
	{
		return dict.Multiply((decimal)multiplier);
	}

	public static Dictionary<string,int> Multiply(this Dictionary<string,int> dict, int multiplier)
	{
		return dict.Multiply((decimal)multiplier);
	}

	public static Dictionary<string,int> Multiply(this Dictionary<string,int> dict, decimal multiplier)
	{
		List<string> keys = new List<string>(dict.Keys);
		foreach(string key in keys){
			dict[key] = (int)((decimal)dict[key] * multiplier);
		}
		return dict;
	}

	public static Dictionary<string,int> Subtract(this Dictionary<string,int> dict, Dictionary<string,int> subtrahend)
	{
		List<string> keys = new List<string>(subtrahend.Keys);
		foreach(string key in keys){
			if (dict.ContainsKey(key) && subtrahend.ContainsKey(key)) {
				dict[key] = dict[key] - subtrahend[key];
			}
		}
		return dict;
	}

	public static Dictionary<string, int> Merge(this Dictionary<string, int> dict1, Dictionary<string, int> dict2)
	{
		List<string> keys = new List<string>(dict2.Keys);
		foreach(string key in keys){
			if(dict1.ContainsKey(key)){
				dict1[key] += dict2[key];
			}else{
				dict1.Add(key, dict2[key]);
			}
		}
		return dict1;
	}

	public static Dictionary<string,int> Negate(this Dictionary<string,int> dict)
	{
		return dict.Multiply(-1);
	}

//	public static string Serialise(this Dictionary<string,string> dict, bool forUI = false, string separator = ",")
//	{
//		return DictUtils.GenerateDictionaryString<string>(dict, forUI, separator);
//	}
//	
//	public static string Serialise(this Dictionary<string,int> dict, bool forUI = false, string separator = ",")
//	{
//		return DictUtils.GenerateDictionaryString<int>(dict, forUI, separator);
//	}
//	
//	public static string Serialise(this Dictionary<string,float> dict, bool forUI = false, string separator = ",")
//	{
//		return DictUtils.GenerateDictionaryString<float>(dict, forUI, separator);
//	}

	public static Dictionary<TKey, TValue> Copy<TKey, TValue>(this Dictionary<TKey, TValue> dict)
	{
		return new Dictionary<TKey, TValue>(dict);
	}
}