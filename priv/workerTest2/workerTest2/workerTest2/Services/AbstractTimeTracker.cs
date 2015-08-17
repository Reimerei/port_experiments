using System;

public abstract class AbstractTimeTracker
{
	public DateTime now;
	public long delta;

	protected AbstractTimeTracker()
	{
		now = default(DateTime);
		delta = 0;
	}
	
	public abstract DateTime Now();
}