using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
	public string sceneToLoad = "Audio Demo";

	public void LoadScene(string sceneName)
	{
		SceneManager.LoadScene(sceneName);
	}
}
