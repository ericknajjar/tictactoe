using System;
using System.Collections.Generic;
using UnityEngine;
namespace Gameplay
{
	public delegate Player CheckBoardStrategieDelegate(IBoard b);

	public class BoardVictoryAnalyser
	{
		HashSet<CheckBoardStrategieDelegate> m_strategies = new HashSet<CheckBoardStrategieDelegate>();

		static readonly CheckBoardStrategieDelegate[] s_rows = new CheckBoardStrategieDelegate[]{FirstRow,SecondRow,ThirdRow};
		static readonly CheckBoardStrategieDelegate[] s_columns = new CheckBoardStrategieDelegate[]{FirstColumn,SecondColumn,ThirdColumn};

		enum DiagonalDirection
		{
			LeftRight = 0, RightLeft = 2
		}

		public Player Check(IBoard board)
		{
			foreach(var checkStrategy in m_strategies)
			{
				var checkResult = checkStrategy (board);
		
				if (!checkResult.Equals (Player.None))
					return checkResult;
			}

			return Player.None;
		}

		public BoardVictoryAnalyser(Point p)
		{
			
			m_strategies.Add (s_rows[p.Y]);
			m_strategies.Add (s_columns[p.X]);

			if (p.X == p.Y)
			{
				m_strategies.Add (LeftRightDiagonal);

				if(p.X == 1)
					m_strategies.Add (RightLeftDiagonal);
			}

			if(Math.Abs(p.X-p.Y) == 2)
				m_strategies.Add (RightLeftDiagonal);
		
		}

		public bool Contains(CheckBoardStrategieDelegate func)
		{
			return m_strategies.Contains(func);
		}

		static IList<Point> MakeRow(int index)
		{
			List<Point> list = new List<Point> (3);

			for (int i = 0; i < 3; ++i) 
			{
				list.Add(Point.Make(i,index));
			}

			return list;
		}

		static IList<Point> MakeDiagonal(DiagonalDirection direction)
		{
			List<Point> list = new List<Point> (3);

			int offset = (int)direction;
			for (int i = 0; i < 3; ++i)
			{
				int x = Mathf.Abs(offset -i);
				int y = i;

				list.Add (Point.Make(x,y));
			}

			return list;
		}

		static IList<Point> MakeColumn(int index)
		{
			List<Point> list = new List<Point> (3);

			for (int i = 0; i < 3; ++i) 
			{
				list.Add(Point.Make(index,i));
			}

			return list;
		}

		static Player Check(IBoard b,IList<Point> points)
		{
			Player player = Player.None;

			for(int i =0;i<points.Count;++i) 
			{
				var point = points[i];
				var cell = b [point];

				System.Console.WriteLine (cell.Owner);
				if(i==0)
					player = cell.Owner;
				else
				{
					if (!player.Equals (cell.Owner)) 
					{
						return Player.None;
					}
				}

			}
			return player;
		}

		public static Player FirstRow(IBoard b)
		{
			var row = MakeRow (0);
			return Check (b, row);
		}

		public static Player SecondRow(IBoard b)
		{
			var row = MakeRow (1);
			return Check (b, row);
		}

		public static Player ThirdRow(IBoard b)
		{
			var row = MakeRow (2);
			return Check (b, row);
		}

		public static Player FirstColumn(IBoard b)
		{
			var column = MakeColumn (0);
			return Check (b, column);
		}

		public static Player SecondColumn(IBoard b)
		{
			var column = MakeColumn (1);
			return Check (b, column);
		}

		public static Player ThirdColumn(IBoard b)
		{
			var column = MakeColumn (2);
			return Check (b, column);
		}

		public static Player LeftRightDiagonal(IBoard b)
		{
			var diagonal = MakeDiagonal (DiagonalDirection.LeftRight);
			return Check(b,diagonal);
		}

		public static Player RightLeftDiagonal(IBoard b)
		{
			var diagonal = MakeDiagonal (DiagonalDirection.RightLeft);
			return Check(b,diagonal);
		}
			
		public static IList<CheckBoardStrategieDelegate> All
		{
			get {
				return new List<CheckBoardStrategieDelegate>{ 
					FirstRow,SecondRow,ThirdRow, FirstColumn,SecondColumn,
					ThirdColumn, LeftRightDiagonal,RightLeftDiagonal,
				};
			}
		}
	}
}

