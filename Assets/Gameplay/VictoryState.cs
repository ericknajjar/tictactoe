using System;

namespace Gameplay
{
	public class VictoryState
	{
		public VictoryState (Player winner,VictoryPattern pattern)
		{
			Winner = winner;
			Pattern = pattern;
		}
			

		public VictoryPattern Pattern{ get; private set;}
		public Player Winner{ get; private set;}

		public static VictoryState Indetermined = new VictoryState(Player.None,VictoryPattern.None);
	}
}

