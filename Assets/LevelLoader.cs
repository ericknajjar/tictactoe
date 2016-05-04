using UnityEngine;
using System.Collections;
using u3dExtensions;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	IPromise<int> m_finishLoad;
	IEnumerator Start()
	{
		yield return null;
		m_finishLoad.Fulfill(SceneManager.GetSceneAt(0).buildIndex);
		Destroy(gameObject);
	}

	public static IFuture<int> LoadLevel(int lvl)
	{
		SceneManager.LoadScene(lvl);

		var go = new GameObject("_levelLoader");

		var lvlLoader = go.AddComponent<LevelLoader>();

		DontDestroyOnLoad(lvlLoader);
		lvlLoader.m_finishLoad = new Promise<int>();

		return lvlLoader.m_finishLoad.Future;
	}
}
