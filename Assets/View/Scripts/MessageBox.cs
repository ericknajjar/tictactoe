using UnityEngine;
using System.Collections;
using u3dExtensions;
using UnityEngine.UI;

public class MessageBox : MonoBehaviour {

	[SerializeField]
	Text m_text;
	IPromise<Unit> m_currentPromisse = null;
	public IFuture<Unit> Show(string msg)
	{
		m_currentPromisse = new Promise<Unit> ();

		m_text.text = msg;

		gameObject.SetActive (true);

		return m_currentPromisse.Future;
	}

	public void OnOk()
	{
		gameObject.SetActive (false);
		m_currentPromisse.Fulfill (Unit.Unit);
	}
}
