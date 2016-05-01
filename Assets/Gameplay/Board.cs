using System;

namespace Gameplay
{
	public class Board: IBoard
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

		private Board(Cell[,] rawData,CheckBoardStrategie checkStrategie)
		{
			m_board = rawData;
			TrippletOwner = checkStrategie.Check(this);

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

			var ret = new Board (rawData, new CheckBoardStrategie(target));

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

