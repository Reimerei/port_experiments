using System.Text;
using System;

public static class StringUtils 
{
}

public static class StringExtension
{
	public static DateTime ToDateTime(this string s)
	{
		return DateTime.Parse(s);
	}

	public static string ConvertToCamelCase(this string text)
	{
		string[] textParts = text.Split(' ');
		if(textParts.Length < 2){
			return text;
		}
		
		for(int i = 1; i < textParts.Length; i++){
			textParts[i] = Capitalise(textParts[i]);
		}
		return string.Concat(textParts);
	}
	
	public static string Capitalise(this string text)
	{
		string firstPart = text.Substring(0, 1).ToUpper();
		string lastPart = text.Substring(1).ToLower();
		
		return firstPart + lastPart;
	}

	public static string JoinEmpty(this string[] strings, string seperator)
	{
		bool hadEntry = false;
		StringBuilder outString = new StringBuilder();
		for(int i=0; i<strings.Length; i++){
			if(!string.IsNullOrEmpty(strings[i])){
				if(hadEntry){
					outString.Append(seperator);
				}
				outString.Append(strings[i]);
				hadEntry = true;
			}
		}
		return outString.ToString();
	}
}