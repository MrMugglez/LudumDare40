using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {

	public Object sceneToLoad;

	public void LoadScene(Object scene)
	{
		SceneManager.LoadScene (1);
	}

	public void ExitGame()
	{
		Application.Quit ();
	}
}
