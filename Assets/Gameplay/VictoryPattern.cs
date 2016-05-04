using System;
using System.Collections.Generic;

namespace Gameplay
{
	public class VictoryPattern
	{
		IList<Point> m_points;

		VictoryPattern (IList<Point> points)
		{
			m_points = points;
		}

		public IList<Point> Points
		{
			get {
				return new List<Point> (m_points);
			}
		}

		enum DiagonalDirection
		{
			LeftRight = 0, RightLeft = 2
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
				int x = Math.Abs(offset -i);
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

		public static VictoryPattern FirstRow = new VictoryPattern(MakeRow(0));
		public static VictoryPattern SecondRow = new VictoryPattern(MakeRow(1));
		public static VictoryPattern ThirdRow = new VictoryPattern(MakeRow(2));

		public static VictoryPattern FirstColumn = new VictoryPattern(MakeColumn(0));
		public static VictoryPattern SecondColumn = new VictoryPattern(MakeColumn(1));
		public static VictoryPattern ThirdColumn = new VictoryPattern(MakeColumn(2));


		public static VictoryPattern LeftRightDiagonal = new VictoryPattern(MakeDiagonal(DiagonalDirection.LeftRight));
		public static VictoryPattern RightLeftDiagonal = new VictoryPattern(MakeDiagonal(DiagonalDirection.RightLeft));

		public static VictoryPattern None = new VictoryPattern(new List<Point>());

	}
}

