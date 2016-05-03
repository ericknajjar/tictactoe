using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace View
{
	public class SceneLoader : MonoBehaviour 
	{
		public void OnPossibleClick()
		{
			SceneManager.LoadScene (1);
		}

		public void OnImpossibleClick()
		{
			SceneManager.LoadScene (1);
		}


		public void OnQuitClick()
		{
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
			#else
				Application.Quit ();
			#endif
		}

	}
}