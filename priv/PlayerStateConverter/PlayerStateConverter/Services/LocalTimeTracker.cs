using System;

public class LocalTimeTracker : AbstractTimeTracker
{
	public override DateTime Now()
	{
		return DateTime.Now;
	}
}