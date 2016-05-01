using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gameplay
{
	[TestFixture]
	public class CheckBoardStrategiesTests
	{
		[Test]
		public void Cell00()
		{
			var estrategies = new CheckBoardStrategie (Point.Make(0,0));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.FirstColumn,CheckBoardStrategie.FirstRow,CheckBoardStrategie.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell01()
		{
			var estrategies = new CheckBoardStrategie (Point.Make(0,1));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.FirstColumn,CheckBoardStrategie.SecondRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell02()
		{
			var estrategies = new CheckBoardStrategie (Point.Make(0,2));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.FirstColumn,CheckBoardStrategie.ThirdRow,CheckBoardStrategie.RightLeftDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell10()
		{
			var estrategies = new CheckBoardStrategie (Point.Make(1,0));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.SecondColumn,CheckBoardStrategie.FirstRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell11()
		{
			var estrategies = new CheckBoardStrategie (Point.Make (1, 1));

				bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.SecondColumn,CheckBoardStrategie.SecondRow,
					CheckBoardStrategie.RightLeftDiagonal,CheckBoardStrategie.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell12()
		{
			var estrategies = new CheckBoardStrategie (Point.Make (1, 2));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.SecondColumn,CheckBoardStrategie.ThirdRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell20()
		{
			var estrategies = new CheckBoardStrategie (Point.Make (2, 0));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.ThirdColumn,CheckBoardStrategie.FirstRow,CheckBoardStrategie.RightLeftDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell21()
		{
			var estrategies = new CheckBoardStrategie (Point.Make (2, 1));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.ThirdColumn,CheckBoardStrategie.SecondRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell22()
		{
			var estrategies = new CheckBoardStrategie (Point.Make (2, 2));

			bool containsOnly = ContainsOnly(estrategies,CheckBoardStrategie.ThirdColumn,CheckBoardStrategie.ThirdRow,CheckBoardStrategie.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		bool ContainsOnly(CheckBoardStrategie strategie,params CheckBoardStrategieDelegate[] funcs)
		{
			var others = new List<CheckBoardStrategieDelegate> (CheckBoardStrategie.All);
			others.RemoveAll ((d) => funcs.Contains (d));

			bool containsOnly = true;

			foreach (var f in funcs)
			{
				containsOnly = containsOnly && strategie.Contains (f);
			}

			foreach (var f in others)
			{
				containsOnly = containsOnly && !strategie.Contains (f);
			}

			return containsOnly;

		}
	}
}

