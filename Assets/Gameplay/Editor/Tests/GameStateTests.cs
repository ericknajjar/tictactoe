using UnityEngine;
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
	}
}