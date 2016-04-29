using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{
	
public class GameState 
{

		public GameState(Player player): this(new List<Move>{ new Move(Point.Make(0,0)),  new Move(Point.Make(1,1)),  new Move(Point.Make(1,1)),
			new Move(Point.Make(1,1)), new Move(Point.Make(1,1)),  new Move(Point.Make(1,1)), 
			new Move(Point.Make(1,1)),  new Move(Point.Make(1,1)),  new Move(Point.Make(1,1)) })
		{

		}

		private GameState(IList<Move> posibleMoves)
		{
			PossibleMoves = posibleMoves;
		}

		public GameState PickAMove(Move move)
		{
			return new GameState (PossibleMoves.Skip (1).ToList());
		}

		public IList<Move> PossibleMoves {
			get;
			private set;
		}
	
}

}
