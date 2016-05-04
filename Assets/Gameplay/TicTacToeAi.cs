using System;
using System.Collections.Generic;


namespace Gameplay
{
	
	public class TicTacToeAi
	{
		AI.MiniMaxAI<AiStateAdapter,Move> m_miniMax = new AI.MiniMaxAI<AiStateAdapter,Move>();
		bool m_perfect;
		Random m_rnd = new Random ();

		public TicTacToeAi (bool perfect = true)
		{
			m_perfect = perfect;
		}

		public Move NextMove(GameState state)
		{
			var adapter = new AiStateAdapter (state);

			if(!m_perfect)
			{
				var possibleMoves = state.PossibleMoves;

				if (m_rnd.NextDouble() < 0.1) 
				{
					return possibleMoves [m_rnd.Next(0, possibleMoves.Count)];
				}
			}
			
			return m_miniMax.NextMove (adapter);
		}

		class AiStateAdapter: AI.IState<Move>
		{
			GameState m_gameState;
			Player m_bot;

			static List<Move> s_badSecondMoves = new List<Move>{new Move(Point.Make(1,0)),new Move(Point.Make(2,1)),new Move(Point.Make(1,2)),new Move(Point.Make(0,1)) };

			public AiStateAdapter(GameState state)
			{
				m_gameState = state;
				m_bot = m_gameState.CurrentPlayer;
			}

			AiStateAdapter(GameState state, Player bot)
			{
				m_gameState = state;
				m_bot = bot;
			}

			#region IState implementation

			public AI.IState<Move> Pick (Move move)
			{
				return new AiStateAdapter (m_gameState.PickAMove (move),m_bot);
			}

			public bool Min
			{
				get{ return !m_gameState.CurrentPlayer.Equals (m_bot);}
			}
			public int Score 
			{
				get 
				{
					
					if (m_gameState.VictoryState.Winner.Equals (m_bot))
						return 10;
					if (m_gameState.VictoryState.Winner.Equals (m_bot.Other))
						return -10;

					return 0;
				}
			}

			public System.Collections.Generic.IList<Move> AllMoves 
			{
				get 
				{
					if (m_gameState.PossibleMoves.Count == 9)
						return new List<Move>{  new Move (Point.Make (1, 1))};
					else if (m_gameState.PossibleMoves.Count == 8) 
					{
						var bestMove = new Move (Point.Make (1, 1));

						if (m_gameState.PossibleMoves.Contains (bestMove))
							return new List<Move>{ bestMove };
						
						var ret = new List<Move> (m_gameState.PossibleMoves);

						foreach(var bad in s_badSecondMoves)
						{
							ret.Remove (bad);
						}

						return ret;
					}

					return new List<Move> (m_gameState.PossibleMoves);
				}
			}

			public bool IsEndState 
			{
				get
				{
					return m_gameState.IsEndState;
				}
			}

			#endregion
		}
	}
}

