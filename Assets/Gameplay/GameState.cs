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

		class Board
		{
			Cell[,] m_board;

			public Board()
			{
				TrippletOwner = Player.None;
				m_board = new Cell[3,3];
				ForEachPoint((p)=>{
					m_board[p.X,p.Y] = new Cell(Player.None);
				});
			}

			public Player TrippletOwner {
				get;
				private set;
			}

			private Board(Cell[,] rawData)
			{
				m_board = rawData;

				int playerX = 0;
				int playerO = 0;

				ForeachCell((cell,p)=>
				{
					if(cell.Owner.Equals(Player.X))
					{
							
							++playerX;
					}
					else if(cell.Owner.Equals(Player.O))
					{
							++playerO;
					}

				});

				if(playerO>2)
					TrippletOwner = Player.O;
				else if(playerX >2)
					TrippletOwner = Player.X;
				
				else
					TrippletOwner = Player.None;
					
			}

			public Cell this[Point p]
			{
				get
				{
					return m_board [p.X, p.Y];
				}
			}

			public Board SetCellOwner(Player player, Point target)
			{
				Cell[,] rawData = new Cell[3, 3];

				ForeachCell ((cell, point) => {
					rawData[point.X,point.Y] = cell;
				});

				rawData[target.X, target.Y] = new Cell(player);

				var ret = new Board (rawData);
				return ret;
			}

			private static void ForEachPoint(System.Action<Point> func)
			{
				for (int i = 0; i < 3; ++i) 
				{
					for (int j = 0; j < 3; ++j) 
					{
						var target = Point.Make(i,j);
						func (target);
					}
				}
			}

			public void ForeachCell(System.Action<Cell,Point> visitior)
			{
				ForEachPoint ((p) => 
				{
					visitior(m_board [p.X, p.Y],p);
				});
						
			}
		}
	
	}

}
