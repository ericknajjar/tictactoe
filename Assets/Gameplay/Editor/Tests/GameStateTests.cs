using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Gameplay
{
	
	[TestFixture]
	public class GameStateTests 
	{
		List<Point> m_starterWins = new List<Point>{
			Point.Make(0,0),Point.Make(0,2),Point.Make(1,0),Point.Make(1,2),Point.Make(2,0)
		};

		List<Point> m_secondWins = new List<Point>{
			Point.Make(0,0),Point.Make(0,2),Point.Make(1,0),Point.Make(1,2),Point.Make(2,1),Point.Make(2,2)
		};

		[Test]
		public void EmptyBoardMustHave9PossibleMoves()
		{
			var gameState = new GameState (Player.X);
			
			Assert.AreEqual (9,gameState.PossibleMoves.Count);
		}

		[Test]
		public void EmptyBoardMustHave8AfterFirstMove()
		{
			var gameState = new GameState (Player.X);

			gameState = gameState.PickAMove (gameState.PossibleMoves[0]);

			Assert.AreEqual (8,gameState.PossibleMoves.Count);
		}


		[Test]
		public void PickAMoveRemovesItFromPossibleMoves()
		{
			var gameState = new GameState (Player.X);

			var move = gameState.PossibleMoves [0];

			gameState = gameState.PickAMove (move);

			var notContains = gameState.PossibleMoves.Count( (m) => {

				return m.Target.Equals(move.Target);
			}) == 0;

			Assert.That (notContains);
		}

		[Test]
		public void EmptyBoardAllPossibleMovements()
		{
			var gameState = new GameState (Player.X);

			var points = new List<Point> ();

			for (int i = 0; i < 3; ++i) 
			{
				for (int j = 0; j < 3; ++j) 
				{
					points.Add (Point.Make(i,j));
				}
			}
				
			foreach(var move in gameState.PossibleMoves)
			{
				points.Remove (move.Target);
			}

			Assert.AreEqual (0,points.Count);
		}

		[Test]
		public void PickMoveChangesCellOwner()
		{
			var gameState = new GameState (Player.X);

			var move = gameState.PossibleMoves [0];

			gameState = gameState.PickAMove (move);

			var cell = gameState [Point.Make (0, 0)];

			Assert.AreEqual (Player.X, cell.Owner);
		}

		[Test]
		public void CellOwnerEqualsCurrentPlayer()
		{
			var gameState = new GameState (Player.O);

			var move = gameState.PossibleMoves [0];

			gameState = gameState.PickAMove (move);

			var cell = gameState [Point.Make (0, 0)];

			Assert.AreEqual (Player.O, cell.Owner);
		}

		[Test]
		public void PickMoveChangesTurn()
		{
			var gameState = new GameState (Player.X);

			var move = gameState.PossibleMoves [1];

			gameState = gameState.PickAMove (move);

			Assert.AreEqual (Player.O, gameState.CurrentPlayer);
		}

		[Test]
		public void XIsVictorious()
		{
			var gameState = new GameState (Player.X);

			foreach(var target in m_starterWins)
			{
				gameState = gameState.PickAMove (new Move (target));
			}

			Assert.AreEqual (Player.X, gameState.Winner);
		}

		[Test]
		public void OIsVictorious()
		{
			var gameState = new GameState (Player.O);

			foreach(var target in m_starterWins)
			{
				gameState = gameState.PickAMove (new Move (target));
			}

			Assert.AreEqual (Player.O, gameState.Winner);
		
		}

		[Test]
		public void OOtherVictoriousO()
		{
			var gameState = new GameState (Player.X);

			foreach(var target in m_secondWins)
			{
				gameState = gameState.PickAMove (new Move (target));
			}

			Assert.AreEqual (Player.O, gameState.Winner);
		}

		/*
		[Test]
		public void OtherVictoriousX()
		{
			var gameState = new GameState (Player.O);

			foreach(var target in m_secondWins)
			{
				gameState = gameState.PickAMove (new Move (target));
			}

			Assert.AreEqual (Player.X, gameState.Winner);
		}*/

		[Test]
		public void NoneVictoriousAfterSingleMove()
		{
			var gameState = new GameState (Player.X);

			foreach(var target in m_secondWins)
			{
				gameState = gameState.PickAMove (new Move (target));
				break;
			}

			Assert.AreEqual (Player.None, gameState.Winner);
		}

		[Test]
		public void EmptyStateNoVictory()
		{
			var gameState = new GameState (Player.X);

			Assert.AreEqual (Player.None, gameState.Winner);
		}
	}
}