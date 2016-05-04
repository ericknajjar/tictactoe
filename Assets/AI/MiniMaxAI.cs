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
				return MiniMax (beginingState, -1000,1000).Move;

			throw new Exception ("Can't determine next move from an end state");
		}


		MoveScore MiniMax(IState<MoveType> s, int alpha, int beta)
		{
			MoveScore best = new MoveScore ();
			List<MoveScore> scores = new List<MoveScore> ();

			foreach (var move in s.AllMoves)
			{
				var newState = s.Pick (move);
				var score = MiniMax (newState, move,alpha,beta);
				var moveScore = new MoveScore (move, score.Score);

				if (!s.Min) 
				{
					if (alpha < moveScore.Score) 
					{
						best = moveScore;
						alpha = moveScore.Score;
					}
						
					if (beta < alpha)
						break;
				}
				else 
				{
					if (beta > moveScore.Score)
					{
						beta = moveScore.Score;
						best = moveScore;
					}

					if (beta < alpha)
						break;
				}
			}

			return best;
		}

		MoveScore MiniMax(IState<MoveType> s, MoveType m,int alpha, int beta)
		{
			if (s.IsEndState)
				return new MoveScore(m,s.Score);
			
			return MiniMax (s,alpha,beta);
		}

		struct MoveScore: IComparable
		{
			public int Score;
			public MoveType Move;

			public MoveScore(MoveType move,int score)
			{
				Move = move;
				Score = score;

			}

			#region IComparable implementation
			public int CompareTo (object obj)
			{
				var other = (MoveScore)obj;

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

