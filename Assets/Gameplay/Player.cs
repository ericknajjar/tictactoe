using System;

namespace Gameplay
{
	public class Player
	{
		private Player ()
		{
		}

		public static Player X
		{
			get{ return new Player ();}
		}
	}
}

