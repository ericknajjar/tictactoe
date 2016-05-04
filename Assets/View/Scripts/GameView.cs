using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using u3dExtensions;

namespace View
{
	public class GameView : MonoBehaviour 
	{
		[SerializeField]
		MessageBox m_messageBox;

		[SerializeField]
		List<Text> m_allTexts = new List<Text>();

		Gameplay.GameState m_gameState = new Gameplay.GameState(Gameplay.Player.X);
		Gameplay.TicTacToeAi m_ai = new Gameplay.TicTacToeAi();

		bool m_botStarts = false;
	
		public void OnQuitClicked()
		{
			SceneManager.LoadScene (0);
		}

		public void OnBoardButtonClicked(int index)
		{
			if (!m_gameState.IsEndState) 
			{
				var point = IndexToPoint (index);
				if (MakeAPlay (new Gameplay.Move (point))) 
				{

					if (!m_gameState.IsEndState) {
						var move = m_ai.NextMove (m_gameState);
						MakeAPlay (move);
					}
				}

			} 
		}

		void NewGame()
		{
			Clear ();
			m_gameState = new Gameplay.GameState (Gameplay.Player.X);
			if (m_botStarts) 
			{
				var move = m_ai.NextMove (m_gameState);
				MakeAPlay (move);
			}
		}

		Point IndexToPoint(int index)
		{
			int y = index  % 3;
			int x = index / 3;

			return Point.Make (x, y);
		}

		int PointToIndex(Point point)
		{
			for (int i = 0; i < 9; ++i)
			{
				var maybe = IndexToPoint (i);
				if (maybe.Equals (point))
					return i;

			}

			return -1;
		}

		bool MakeAPlay(Gameplay.Move move)
		{
			if (m_gameState.PossibleMoves.Contains (move))
			{
				m_gameState = m_gameState.PickAMove (move);
				UpdateView ();

				if (m_gameState.IsEndState) 
				{
					EndGame ();
				}

				return true;
			}

			return false;
		}

		void EndGame()
		{
			string msg = "It's a draw!";

			if (!m_gameState.VictoryState.Winner.Equals (Gameplay.Player.None)) 
			{
				msg = m_gameState.VictoryState.Winner + " is the winner!";

				foreach (var point in m_gameState.VictoryState.Pattern.Points) 
				{
					var index = PointToIndex (point);
					m_allTexts [index].color = Color.red;
				}
			}

			m_botStarts = !m_botStarts;

			m_messageBox.Show (msg).Map((u)=>{
				NewGame();

			});
		}

		void Clear()
		{
			foreach (var text in m_allTexts)
			{
				text.text = "";
				text.color = Color.black;
			}
		}

		void UpdateView()
		{
			int index = 0;
			m_gameState.ForEachCell((cell,p) =>{


				var owner = cell.Owner;
				if(!owner.Equals(Gameplay.Player.None))
				{
					m_allTexts[index].text = owner.ToString();
				}
				++index;
			});
				
		}

	}
}
