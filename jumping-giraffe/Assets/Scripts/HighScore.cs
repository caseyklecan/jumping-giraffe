using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HighScore : MonoBehaviour {
	static public int score = 0;

	public Text highScore;
//	private GameObject highScoreGO;

	void Awake () {
//		highScoreGO = GameObject.Find("Title");
//		highScore = highScoreGO.GetComponent<Text> ();
		score = PlayerPrefs.GetInt("JumpingGiraffeHighScore", 0);
		highScore.text = "High Score: " + score.ToString();
	}

}
