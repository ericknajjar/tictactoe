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

