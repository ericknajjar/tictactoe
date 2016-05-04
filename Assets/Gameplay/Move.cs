using UnityEngine;
using System.Collections;

namespace Gameplay 
{
	
	public class Move 
	{
		Point m_target;

		public Move(Point target)
		{
			m_target = target;
		}

		public Point Target{ get{ return m_target;}}

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
