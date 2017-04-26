using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointCounter : MonoBehaviour {

	public AchievementController achievements;
	private float time;
	private int timeInt;
	private int score;
	private Text appleGT;
	private GameObject appleGO;

	private int appleMultiplier = 1;

	// Use this for initialization
	void Start () {
		appleGO = GameObject.Find ("AppleCounter");
		appleGT = appleGO.GetComponent<Text> ();
		appleGT.text = "Points: 0";
		time = 0.0f;
		if (PlayerPrefs.HasKey("JumpingGiraffeHighScore"))
		{
			score = PlayerPrefs.GetInt("JumpingGiraffeHighScore");
			Debug.Log ("High score is currently: " + score);
		}
		else
		{
			score = 0;
		}
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		timeInt = (int)time;
		appleGT.text = "Points: " + timeInt.ToString();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Apple"))
		{
			time += (10.0f * appleMultiplier);
		}
	}

	public void SetMultiplier(int x) { 
		appleMultiplier = x;
	}

	public int getScore() {
		return timeInt;
	}

	public void setScore(int x) {
		timeInt = x;
	}

	void OnDisable()
	{
		if (timeInt > score) {
			PlayerPrefs.SetInt("JumpingGiraffeHighScore", timeInt);
			PlayerPrefs.Save ();
			Debug.Log ("Saving new high score of: " + timeInt);
		}

		// achievement logic
		if (score > 20) { 
			achievements.SetPinkUnlocked();
		}

		if (score > 40) { 
			achievements.SetBlueUnlocked();
		}
	}
		
	public void ClickRegular() { 
		appleMultiplier = 1;
	}

	public void ClickPink() { 
		appleMultiplier = 2;
	}

	public void ClickBlue() { 
		appleMultiplier = 1;
	}
}
