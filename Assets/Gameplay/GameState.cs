using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{



public class GameState 
{
		public Player CurrentPlayer{ get; private set;}
		public VictoryState VictoryState{ get{ return m_board.VictoryState;}}

		Board m_board;

		public GameState (Player player) : this (player, new Board ())
		{
			
		}

		private GameState(Player player,Board b)
		{
			m_board = b;
			PossibleMoves = CreateAllMoves (m_board);
			CurrentPlayer = player;

		}
			

		private static List<Move> CreateAllMoves(Board board)
		{
			var moves = new List<Move> (9);

			board.ForeachCell ((cell,p) => {
				if(cell.Owner.Equals(Player.None))
					moves.Add (new Move(p));
			});

			return moves;
		}
			
		public GameState PickAMove(Move move)
		{
			if (!PossibleMoves.Contains (move))
				throw new System.Exception ("Can't play an impossible move: "+move);
			
			var newBoard = m_board.SetCellOwner (CurrentPlayer, move.Target);

			return new GameState (CurrentPlayer.Other, newBoard);
		}

		public void ForEachCell(System.Action<Cell,Point> visitor)
		{
			m_board.ForeachCell (visitor);
		}

		public bool IsEndState
		{
			get{
				return !VictoryState.Winner.Equals (Player.None) || PossibleMoves.Count == 0;
			}
		} 

		public Cell this[Point p]
		{
			get
			{
				return m_board[p];
			}
		}

		public IList<Move> PossibleMoves {
			get;
			private set;
		}
			
	
	}

}
