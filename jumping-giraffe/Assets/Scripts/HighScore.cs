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
		if (PlayerPrefs.HasKey("JumpingGiraffeHighScore"))
		{
			score = PlayerPrefs.GetInt("JumpingGiraffeHighScore");
		}
		else
		{
			score = 0;
		}
		PlayerPrefs.SetInt("JumpingGiraffeHighScore", score);
		highScore.text = "High Score: " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		highScore.text = "High Score: " + score.ToString();
		PointCounter pcScript = Camera.main.GetComponent<PointCounter>();
		if (pcScript.getScore() > score)
		{
			score = pcScript.getScore();
			PlayerPrefs.SetInt("JumpingGiraffeHighScore", score);
		}
	}
}
