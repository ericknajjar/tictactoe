using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;

[TestFixture]
public class TicTacToeAiTests  
{

	AiCase m_starterAlmostWins = new AiCase(new List<Point>{Point.Make(0,0),Point.Make(0,2),Point.Make(1,0),Point.Make(1,2)},
		new List<Point>{Point.Make(2,0)}, Gameplay.Player.X);

	AiCase m_playOnTheCorners = new AiCase(new List<Point>{Point.Make(1,1)},
		new List<Point>{Point.Make(0,0),Point.Make(2,0),Point.Make(0,2),Point.Make(2,2)}, Gameplay.Player.X);

	AiCase m_openingMove = new AiCase(new List<Point>(),
		new List<Point>{Point.Make(1,1),Point.Make(0,0),Point.Make(2,0),Point.Make(0,2),Point.Make(2,2)}, Gameplay.Player.X);


	Gameplay.TicTacToeAi  m_ai = new Gameplay.TicTacToeAi ();

	[Test]
	public void AssertingWinPremiss()
	{
		var winningState = m_starterAlmostWins.State.PickAMove (m_starterAlmostWins.NextMoves [0]);

		Assert.AreEqual (Gameplay.Player.X,winningState.VictoryState.Winner);
	}

	[Test]
	public void ChooseRightToVictoryMove1()
	{
		TestAiCase (m_starterAlmostWins);
	}

	[Test]
	public void PlayOnCorners()
	{
		TestAiCase (m_playOnTheCorners);
	}


	[Test]
	public void OpeningMove()
	{
		TestAiCase (m_openingMove);
	}

	void TestAiCase(AiCase aiCase)
	{
		var move = m_ai.NextMove (aiCase.State);

		bool contains = aiCase.NextMoves.Contains (move);

		var list = new StringBuilder ();
		list.Append ("[");
		foreach(var possibleMove in aiCase.NextMoves)
		{
			list.Append (possibleMove);
			list.Append (",");
		}
		list.Append ("]");

		Assert.That (contains, move+" should be in" + list);
	}

	[Test]
	public void StrangeWeakCase()
	{
		List<Point> playerMoves = new List<Point>{ Point.Make(0,2),Point.Make(2,0),Point.Make(2,2),Point.Make(1,2) };
		var gameState = new Gameplay.GameState (Gameplay.Player.X);

		foreach(var point in playerMoves)
		{
			var move = new Gameplay.Move (point);

			if (gameState.PossibleMoves.Contains (move))
				gameState = gameState.PickAMove (move);
			else
				gameState = gameState.PickAMove (gameState.PossibleMoves[0]);

			if (gameState.IsEndState)
				break;

			var aiMove = m_ai.NextMove (gameState);
			gameState = gameState.PickAMove(aiMove);
		}

		Assert.AreEqual (Gameplay.Player.O, gameState.VictoryState.Winner);
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

		bool draw = gameState.PossibleMoves.Count == 0 && gameState.VictoryState.Winner.Equals (Gameplay.Player.None);

		Assert.That (draw, "Move Count: "+gameState.PossibleMoves.Count+" Winner: "+gameState.VictoryState.Winner);
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
