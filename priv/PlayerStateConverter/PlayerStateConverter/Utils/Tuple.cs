public struct Tuple<TA,TB>
{
	public TA first;
	public TB second;

	public Tuple(TA first, TB second)
	{
		this.first = first;
		this.second = second;
	}

	public override string ToString()
	{
		return "[" + ToString<TA>(first) + "," + ToString<TB>(second) + "]";
	}

	string ToString<T>(T item)
	{
		if(typeof(T) == typeof(int) || typeof(T) == typeof(float) || typeof(T) == typeof(double)){
			return "" + item;
		}
		return "\"" + item + "\"";
	}
}