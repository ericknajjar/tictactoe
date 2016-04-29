using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;

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

	}
}