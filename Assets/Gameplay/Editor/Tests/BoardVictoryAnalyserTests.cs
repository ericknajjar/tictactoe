using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gameplay
{
	[TestFixture]
	public class BoardVictoryAnalyserTests
	{
		[Test]
		public void Cell00()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make(0,0));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.FirstColumn,BoardVictoryAnalyser.FirstRow,BoardVictoryAnalyser.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell01()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make(0,1));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.FirstColumn,BoardVictoryAnalyser.SecondRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell02()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make(0,2));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.FirstColumn,BoardVictoryAnalyser.ThirdRow,BoardVictoryAnalyser.RightLeftDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell10()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make(1,0));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.SecondColumn,BoardVictoryAnalyser.FirstRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell11()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make (1, 1));

				bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.SecondColumn,BoardVictoryAnalyser.SecondRow,
					BoardVictoryAnalyser.RightLeftDiagonal,BoardVictoryAnalyser.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell12()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make (1, 2));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.SecondColumn,BoardVictoryAnalyser.ThirdRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell20()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make (2, 0));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.ThirdColumn,BoardVictoryAnalyser.FirstRow,BoardVictoryAnalyser.RightLeftDiagonal);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell21()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make (2, 1));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.ThirdColumn,BoardVictoryAnalyser.SecondRow);

			Assert.That (containsOnly);
		}

		[Test]
		public void Cell22()
		{
			var estrategies = new BoardVictoryAnalyser (Point.Make (2, 2));

			bool containsOnly = ContainsOnly(estrategies,BoardVictoryAnalyser.ThirdColumn,BoardVictoryAnalyser.ThirdRow,BoardVictoryAnalyser.LeftRightDiagonal);

			Assert.That (containsOnly);
		}

		bool ContainsOnly(BoardVictoryAnalyser strategie,params CheckBoardStrategieDelegate[] funcs)
		{
			var others = new List<CheckBoardStrategieDelegate> (BoardVictoryAnalyser.All);
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

