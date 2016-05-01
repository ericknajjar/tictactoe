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
		public void EmptyBoardHasNoTripplet()
		{
			var board = new Board ();

			Assert.AreEqual (Player.None, board.TrippletOwner);
		}

		[Test]
		public void FirstRow()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (2, 0));

			Assert.AreEqual (Player.X, board.TrippletOwner);
		}

		[Test]
		public void FirstRowOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (2, 0));
			board = board.SetCellOwner (Player.X, Point.Make (0, 1));

			Assert.AreEqual (Player.None, board.TrippletOwner);
		}

		[Test]
		public void SecondRowOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 1));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (2, 1));
			board = board.SetCellOwner (Player.X, Point.Make (0, 2));

			Assert.AreEqual (Player.None, board.TrippletOwner);
		}

		[Test]
		public void FirstColumn()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (0, 0));
			board = board.SetCellOwner (Player.X, Point.Make (0, 1));
			board = board.SetCellOwner (Player.X, Point.Make (0, 2));


			Assert.AreEqual (Player.X, board.TrippletOwner);
		}

		[Test]
		public void SecondColumn()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.X, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (1, 2));


			Assert.AreEqual (Player.X, board.TrippletOwner);
		}

		[Test]
		public void SecondColumnOBreaks()
		{
			var board = new Board ();

			board = board.SetCellOwner (Player.X, Point.Make (1, 0));
			board = board.SetCellOwner (Player.O, Point.Make (1, 1));
			board = board.SetCellOwner (Player.X, Point.Make (1, 2));
			board = board.SetCellOwner (Player.X, Point.Make (2, 2));

			Assert.AreEqual (Player.None, board.TrippletOwner);
		}
	}
}

