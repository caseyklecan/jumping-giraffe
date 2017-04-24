using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour {
	static public int score = 0;
	private GameObject highScoreGO;
	public Text highScore;

	void Awake () {
		highScoreGO = GameObject.Find("Title");
		highScore = highScoreGO.GetComponent<Text> ();
		score = PlayerPrefs.GetInt("JumpingGiraffeHighScore", 0);
		highScore.text = "High Score: " + score.ToString();
	}

}
