using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;

[TestFixture]
public class TicTacToeAiTests  
{

	AiCase m_starterAlmostWins = new AiCase(new List<Point>{Point.Make(0,0),Point.Make(0,2),Point.Make(1,0),Point.Make(1,2)},
		new List<Point>{Point.Make(2,0)}, Gameplay.Player.X);

	Gameplay.TicTacToeAi  m_ai = new Gameplay.TicTacToeAi ();

	[Test]
	public void AssertingWinPremiss()
	{
		var winningState = m_starterAlmostWins.State.PickAMove (m_starterAlmostWins.NextMoves [0]);

		Assert.AreEqual (Gameplay.Player.X,winningState.Winner);
	}

	[Test]
	public void ChooseRightToVictoryMove1()
	{
		var move = m_ai.NextMove (m_starterAlmostWins.State);

		bool contains = m_starterAlmostWins.NextMoves.Contains (move);

		Assert.That (contains, "Should be " + m_starterAlmostWins.NextMoves[0]+ " but was "+ move);
	}

	[Test, Timeout(10000)]
	public void AiVsAiDraw()
	{
		var gameState = new Gameplay.GameState (Gameplay.Player.X);

		while(!gameState.IsEndState)
		{
			var move = m_ai.NextMove (gameState);
			gameState = gameState.PickAMove (move);

		}

		bool draw = gameState.PossibleMoves.Count == 0 && gameState.Winner.Equals (Gameplay.Player.None);

		Assert.That (draw, "Move Count: "+gameState.PossibleMoves.Count+" Winner: "+gameState.Winner);
	}

	class AiCase
	{
		public Gameplay.GameState State {
			get;
			private set;
		}

		public IList<Gameplay.Move> NextMoves {
			get;
			private set;
		}

		public AiCase (IList<Point> moves, IEnumerable<Point> nextMoves, Gameplay.Player player)
		{
			State = new Gameplay.GameState(player);

			foreach(var point in moves)
			{
				State = State.PickAMove(new Gameplay.Move(point));
			}

			NextMoves = new List<Gameplay.Move>();

			foreach(var point in nextMoves)
			{
				NextMoves.Add(new Gameplay.Move(point));
			}

		}
	}
}
