﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

namespace View
{
	public class GameView : MonoBehaviour 
	{
		[SerializeField]
		List<Text> m_allTexts = new List<Text>();

		Gameplay.GameState m_gameState = new Gameplay.GameState(Gameplay.Player.X);
		Gameplay.TicTacToeAi m_ai = new Gameplay.TicTacToeAi();

		public void OnQuitClicked()
		{
			SceneManager.LoadScene (0);
		}

		public void OnBoardButtonClicked(int index)
		{
			if (m_gameState.Winner.Equals (Gameplay.Player.None)) 
			{
				var point = IndexToPoint (index);
				MakeAPlay (new Gameplay.Move(point));

				if (!m_gameState.IsEndState) 
				{
					var move = m_ai.NextMove (m_gameState);
					MakeAPlay (move);
				}
			}

		}

		Point IndexToPoint(int index)
		{
			int y = index  % 3;
			int x = index / 3;
			return Point.Make (x, y);
		}

		void MakeAPlay(Gameplay.Move move)
		{
			m_gameState = m_gameState.PickAMove (move);
			UpdateView ();
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

			Debug.Log ("Winner: "+m_gameState.Winner);
		}

		[System.Serializable]
		public class Seri
		{
			[SerializeField]
			int a;
			[SerializeField]
			int b;
		}

	}
}
