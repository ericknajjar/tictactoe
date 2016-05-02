using UnityEngine;
using System.Collections;

public struct Point 
{
	public int X{ get; private set;}
	public int Y{ get; private set;}

	public static Point Make(int x, int y)
	{
		var p = new Point ();

		p.X = x;
		p.Y = y;

		return p;
	}

	public override bool Equals (object obj)
	{
		if (obj == null)
			return false;
		if (ReferenceEquals (this, obj))
			return true;
		if (obj.GetType () != typeof(Point))
			return false;
		Point other = (Point)obj;
		return X == other.X && Y == other.Y;
	}
	

	public override int GetHashCode ()
	{
		unchecked {
			return X.GetHashCode () ^ Y.GetHashCode ();
		}
	}

	public override string ToString ()
	{
		return string.Format ("[Point: X={0}, Y={1}]", X, Y);
	}
	
}


