using System;

public class TimeService
{
	static TimeService singleton = new TimeService();

	private TimeService()
	{
		init<LocalTimeTracker>();
	}

	protected AbstractTimeTracker timeTracker;

	#region Public API

	public static void Init<T>(DateTime? baseTime = null) where T : AbstractTimeTracker, new()
	{
		singleton.init<T>(baseTime);
	}

	public static DateTime Now
	{
		get { return singleton.now; }
	}

	public static DateTime UtcNow
	{
		get { return singleton.utcNow; }
	}

	#endregion

	void init<T>(DateTime? baseTime = null) where T : AbstractTimeTracker, new()
	{
		timeTracker = new T();
		if(baseTime != null){
			if(timeTracker.GetType() == typeof(LocalTimeTracker)){
//				Debug.LogWarning("LocalTimeTracker will not make use of 'baseTime'!");
			}else{
				timeTracker.now = baseTime.Value;
				timeTracker.delta = baseTime.Value.Subtract(DateTime.Now).Ticks;
			}
		}
	}

	DateTime now
	{
		get { return timeTracker.Now(); }
	}

	DateTime utcNow
	{
		get { return timeTracker.Now().ToUniversalTime(); }
	}
}