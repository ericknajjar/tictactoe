using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gameplay
{
	[TestFixture]
	public class BoardTests
	{
		[Test]
		public void EmptyBoardHasNoWinner()
		{
			var board = new Board ();

			Assert.AreEqual (VictoryState.Indetermined, board.VictoryState);
		}

		[Test]
		public void FirstRow()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (2, 0));

			Assert.AreEqual (Player.X, board.VictoryState.Winner);
		}

		[Test]
		public void FirstRowOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (2, 0));
			board = board.SetCellOwner (Player.X, Point.Make (0, 1));

			Assert.AreEqual (Player.None,board.VictoryState.Winner);
		}

		[Test]
		public void SecondRowOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 1));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (2, 1));
			board = board.SetCellOwner (Player.X, Point.Make (0, 2));

			Assert.AreEqual (Player.None,board.VictoryState.Winner);
		}

		[Test]
		public void FirstColumn()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.X, Point.Make (0, 1));
			board = board.SetCellOwner (Player.X, Point.Make (0, 2));


			Assert.AreEqual (Player.X, board.VictoryState.Winner);
		}

		[Test]
		public void SecondColumn()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (1, 2));


			Assert.AreEqual (Player.X, board.VictoryState.Winner);
		}

		[Test]
		public void SecondColumnOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (1, 2));
			board = board.SetCellOwner (Player.X, Point.Make (2, 2));

			Assert.AreEqual (Player.None,board.VictoryState.Winner);
		}

		[Test]
		public void LeftRightDiagonal()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.O, Point.Make (0, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.O, Point.Make (2, 2));
			board = board.SetCellOwner (Player.X, Point.Make (0, 1));
			board = board.SetCellOwner (Player.X, Point.Make (0, 2));

			Assert.AreEqual (Player.O,board.VictoryState.Winner);
		}

		[Test]
		public void RightLeftDiagonal()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.O, Point.Make (2, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.O, Point.Make (0, 2));
			board = board.SetCellOwner (Player.X, Point.Make (2, 1));
			board = board.SetCellOwner (Player.X, Point.Make (2, 2));

			Assert.AreEqual (Player.O, board.VictoryState.Winner);
		}

		[Test]
		public void NoVitory()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (1, 1));

			Assert.AreEqual (Player.None,board.VictoryState.Winner);
		}
	}
}

