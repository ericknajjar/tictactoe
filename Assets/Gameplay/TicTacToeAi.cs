using System;
using System.Collections.Generic;

namespace Gameplay
{
	public class TicTacToeAi
	{
		AI.MiniMaxAI<AiStateAdapter,Move> m_miniMax = new AI.MiniMaxAI<AiStateAdapter,Move>();

		public TicTacToeAi ()
		{
			
		}

		public Move NextMove(GameState state)
		{
			var adapter = new AiStateAdapter (state);
			
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
					
					if (m_gameState.Winner.Equals (m_bot))
						return 10;
					if (m_gameState.Winner.Equals (m_bot.Other))
						return -10;

					return 0;
				}
			}

			public System.Collections.Generic.IList<Move> AllMoves {
				get {
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

