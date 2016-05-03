using UnityEngine;
using System.Collections;

namespace Gameplay 
{
	
	public class Move 
	{
		
		public Move(Point target)
		{
			Target = target;
		}

		public Point Target{ get; private set;}

		public override bool Equals (object obj)
		{
			if (obj == null)
				return false;
			if (ReferenceEquals (this, obj))
				return true;
			if (obj.GetType () != typeof(Move))
				return false;
			Move other = (Move)obj;

			return Target.Equals(other.Target);
		}
		

		public override int GetHashCode ()
		{
			unchecked {
				return Target.GetHashCode ();
			}
		}

		public override string ToString ()
		{
			return string.Format ("[Move: Target={0}]", Target);
		}
		

	}
}
