using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay
{



public class GameState 
{
		public Player CurrentPlayer{ get; private set;}
		public Player Winner{ get{ return m_board.TrippletOwner;}}

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
			var newBoard = m_board.SetCellOwner (CurrentPlayer, move.Target);

			return new GameState (CurrentPlayer.Other, newBoard);
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
