using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace View
{
	public class GameView : MonoBehaviour 
	{

		public void OnQuitClicked()
		{
			SceneManager.LoadScene (0);
		}

	}
}
