using System;
using System.Collections.Generic;

namespace AI
{
	public class MiniMaxAI<State,MoveType> where State:IState<MoveType>
	{
		public MiniMaxAI()
		{

		}

		public MoveType NextMove(State beginingState)
		{
			if(!beginingState.IsEndState)
				return MiniMax (beginingState).Move;

			throw new Exception ("Can't determine next move from an end state");
		}


		MoveScore MiniMax(IState<MoveType> s)
		{
			List<MoveScore> scores = new List<MoveScore> ();

			foreach (var move in s.AllMoves)
			{
				var newState = s.Pick (move);
				var score = MiniMax (newState, move);

				scores.Add (new MoveScore(move,score.Score));
			}

			scores.Sort ((a,b)=> b.CompareTo(a));


			return scores [0];
		}

		MoveScore MiniMax(IState<MoveType> s, MoveType m)
		{
			if (s.IsEndState)
				return new MoveScore(m,s.Score);
			
			return MiniMax (s);
		}

		class MoveScore: IComparable
		{
			public int Score{ get; private set;}
			public MoveType Move{ get; private set;}

			public MoveScore(MoveType move,int score)
			{
				Move = move;
				Score = score;

			}

			#region IComparable implementation
			public int CompareTo (object obj)
			{
				var other = obj as MoveScore;

				return Score.CompareTo (other.Score);
			}
			#endregion

			public override string ToString ()
			{
				return string.Format ("[MoveScore: Score={0}, Move={1}]", Score, Move);
			}
		}

	}
}

