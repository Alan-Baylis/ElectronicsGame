using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ScriptMenuScene : MonoBehaviour {

	// Use this for initialization
	public void startPlayScene () {
        SceneManager.LoadScene("scene", LoadSceneMode.Single);
	}

    public void exitGame()
    {
        Application.Quit();
    }
}
