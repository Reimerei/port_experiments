public struct IntVector2
{
	public int x, y;

	public IntVector2(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	public override bool Equals(object obj)
	{
		if(obj is IntVector2){
			IntVector2 v =(IntVector2)obj;
			return x == v.x && y == v.y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return x + y;
	}

	public override string ToString()
	{
		return "("+x+","+y+")";
	}
}