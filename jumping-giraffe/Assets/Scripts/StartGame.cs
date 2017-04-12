using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	public void Clicked() {
		SceneManager.LoadScene ("mainScene");	
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("startScene");
    }

	public void Instructions() {
		SceneManager.LoadScene ("instructionScene");
	}

}
