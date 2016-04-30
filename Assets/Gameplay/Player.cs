using System;

namespace Gameplay
{
	public class Player
	{
		string m_name;

		private Player (string name)
		{
			m_name = name;
		}

		static Player()
		{
			X = new Player ("X");
			O = new Player ("O");
			None = new Player ("None");
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

		public override string ToString ()
		{
			return m_name;
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

