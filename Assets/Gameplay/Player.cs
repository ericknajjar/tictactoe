using System;

namespace Gameplay
{
	public class Player
	{
		private Player ()
		{
		}

		static Player()
		{
			X = new Player ();
			O = new Player ();
			None = new Player ();
		}

		public Player Other
		{
			get
			{
				if (this.Equals (X))
					return O;
				else if (this.Equals (None))
					return None;

				return X;
			}
		} 

		public static Player X {
			get;
			private set;
		}

		public static Player None {
			get;
			private set;
		}

		public static Player O {
			get;
			private set;
		}
	}
}

