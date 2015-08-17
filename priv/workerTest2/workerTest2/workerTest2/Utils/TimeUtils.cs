using System;

public static class TimeUtils 
{
	const long TicksPerMicrosecond = 10;

	public static DateTime Epoch()
	{
		return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
	}

//	public static long GetMicrosecondsFromEpoch()
//	{
//		return TimeService.UtcNow.GetMicrosecondsFromEpoch();
//	}

	public static long GetMicrosecondsFromEpoch(this DateTime time)
	{
		return (time - Epoch()).Ticks / TicksPerMicrosecond;
	}

	public static DateTime GetDateTimeFromMicroseconds(this long time)
	{
		long ticks = time * TicksPerMicrosecond;
		
		return Epoch().AddTicks(ticks);
	}

	public static string DisplayFormattedTime(int totalSeconds, bool shortFormat = true)
	{
		if(totalSeconds >= 86400){
			return DisplayDaysTime(totalSeconds, shortFormat);
		}

		if(totalSeconds >= 3600){
			return DisplayHoursTime(totalSeconds, shortFormat);
		}

		if(totalSeconds >= 60){
			return DisplayMinsTime(totalSeconds, shortFormat);
		}

		return DisplaySecondsTime(totalSeconds);
	}

	static string DisplayDaysTime(int totalSeconds, bool shortFormat)
	{
		int days = GetDays(totalSeconds);
		int hours = GetHours(totalSeconds);

		if(shortFormat && hours == 0){
			return days + "d";
		}

		return days + "d " + hours + "h";
	}

	static string DisplayHoursTime(int totalSeconds, bool shortFormat)
	{
		int hours = GetHours(totalSeconds);
		int mins = GetMinutes(totalSeconds);

		if(shortFormat && mins == 0){
			return hours + "h";
		}

		return hours + "h " + mins + "min";
	}

	static string DisplayMinsTime(int totalSeconds, bool shortFormat)
	{
		int mins = GetMinutes(totalSeconds);
		int seconds = GetSeconds(totalSeconds);

		if(shortFormat && seconds == 0){
			return mins + "min";
		}
		
		return mins + "min " + seconds + "s";
	}
	
	static string DisplaySecondsTime(int totalSeconds)
	{
		int seconds = GetSeconds(totalSeconds);
		
		return seconds + "s";
	}

	static int GetDays(int seconds)
	{
		return seconds / 86400;
	}
	
	static int GetHours(int seconds)
	{
		return (seconds % 86400)/ 3600;
	}

	static int GetMinutes(int seconds)
	{
		return (seconds % 3600) / 60;
	}

	static int GetSeconds(int seconds)
	{
		return (seconds % 3600) % 60;
	}
}