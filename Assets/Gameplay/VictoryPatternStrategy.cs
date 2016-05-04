using System;

namespace Gameplay
{
	
	public class VictoryPatternStrategy
	{
		public VictoryPatternStrategy(VictoryPattern pattern)
		{
			Pattern = pattern;
		}

		public VictoryPattern Pattern{ get; private set;}

		public Player Check(IBoard b)
		{
			Player player = Player.None;
			var points = Pattern.Points;

			for (int i = 0; i < points.Count; ++i) {
				var point = points [i];
				var cell = b [point];

				if (cell.Owner.Equals (Player.None))
					return Player.None;

				if (i == 0)
					player = cell.Owner;
				else {
					if (!player.Equals (cell.Owner)) {
						return Player.None;
					}
				}

			}

			return player;
		}
	}

}

