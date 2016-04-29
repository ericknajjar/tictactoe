using UnityEngine;
using System.Collections;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using System;

namespace AI
{
	public interface IMove
	{
		
	}

	public class Score: IComparable
	{
		private int Value{ get; set;}
		public Score(int value)
		{

		}

		#region IComparable implementation
		public int CompareTo (object obj)
		{
			var otherScore = obj as Score;

			if (otherScore == null) {
				return -1;
			}

			return Value.CompareTo (otherScore.Value);
		}
		#endregion


	}

	public interface IState<Move> where Move: IMove
	{
		IList<Move> PossibleMoves{ get;}
		IComparable Score { get;}
	}

	public class MiniMaxAI<State,Move> where State : IState<Move> where Move: IMove
	{
		public MiniMaxAI()
		{
			
		}

		public Move NextMove(State currentState)
		{
			return currentState.PossibleMoves [0];
		}
	}

	[TestFixture]
	public class MinMaxTest 
	{
		Mock<IState<IMove>> m_goodState;
		Mock<IState<IMove>> m_badState;

		public MinMaxTest()
		{
			m_badState = new Mock<IState<IMove>> ();
			m_goodState = new Mock<IState<IMove>> ();

			m_badState.SetupGet ((x) => x.Score).Returns (new Score (-10));
			m_goodState.SetupGet ((x) => x.Score).Returns (new Score (10));
		}

		[Test]
		public void NextMoveVictory()
		{
			var moq = new Mock<IState<IMove>> ();
			var moveA = new Mock<IMove> ().Object;
			var moveB = new Mock<IMove> ().Object;

			moq.SetupGet ((x) => x.PossibleMoves).Returns (new List<IMove>{moveA,moveB});

			var minimaxAI = new MiniMaxAI<IState<IMove>, IMove>();

			IMove move = minimaxAI.NextMove (moq.Object);

			Assert.AreEqual (moveA, move);
		}
	}
}

