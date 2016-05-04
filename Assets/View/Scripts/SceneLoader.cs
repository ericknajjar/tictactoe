using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using u3dExtensions.IOC;
using u3dExtensions.IOC.extensions;
using u3dExtensions;

namespace View
{
	public class SceneLoader : MonoBehaviour 
	{
		public void OnPossibleClick()
		{
			LevelLoader.LoadLevel (1).Map ((lvl) => {
				GlobalContext.Instance.Context.Get<GameView> (InnerBindingNames.Empty,false);
			});


		}

		public void OnImpossibleClick()
		{
			LevelLoader.LoadLevel (1).Map ((lvl) => {
				GlobalContext.Instance.Context.Get<GameView> (InnerBindingNames.Empty,true);
			});
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