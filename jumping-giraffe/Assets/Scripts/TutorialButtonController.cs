using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialButtonController : MonoBehaviour {

	public TutorialGiraffeController gf;
	public Text description;
	public Text buttonText;

	public GameObject starPrefab, speedPrefab, applePrefab;

	private string tryText, gotItText, describeJump, describeDeath, describeStar, describeSpeed, describeApple, describeWin, goToGame;
	private bool active = false;

	// Use this for initialization
	void Start () {
		tryText = "Try it!";
		gotItText = "Got it!";
		describeJump = "Jump on your pogo stick to catch up with the other giraffes! Swipe right to flip in the air and go farther!";
		describeDeath = "Don't fall in the valleys between the hills! You'll fly off the hill and lose :(";
		describeStar = "If you pick up a star, you'll be invincible for a few seconds";
		describeSpeed = "If you pick up lightning, you'll go extra fast for a few seconds";
		describeApple = "Pick up apples to get extra points along your way!";
		describeWin = "You have 30 seconds to catch up to the other giraffes :)";

		description.text = describeJump;
		buttonText.text = tryText;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick() {
		ToggleActive ();
		int section = gf.GetSection ();
		switch (section) {
		case 0:
			description.text = describeJump;
			break;
		case 1:
			description.text = describeSpeed;
			if (active)
				SetUpSpeed ();
			break;
		case 2:
			description.text = describeStar;
			if (active) 
				SetUpStar ();
			break;
		case 3:
			description.text = describeApple;
			if (active)
				SetUpApple ();
			break;
		case 5: 
			description.text = describeWin;
			buttonText.text = "Main Menu";
			if (active) 
				SceneManager.LoadScene ("startScene");
			break;
		case 4:
			description.text = describeDeath;

			break;
		default:
			break;
		}
	}

	void ToggleActive() {
		gf.ToggleActive ();
		active = !active;
		if (active) {
			buttonText.text = gotItText;
		} else {
			buttonText.text = tryText;
			ResetGiraffe ();
		}
	}

	void ResetGiraffe() {
//		gf.ResetPosition ();
	}

	void SetUpStar() {
		Vector3 starPos = new Vector3 (gf.transform.position.x + 5f, 2f, 0f);
		Instantiate (starPrefab, starPos, Quaternion.identity);
	}

	void SetUpSpeed() { 
		Vector3 speedPos = new Vector3 (gf.transform.position.x + 5f, 2f, 0f);
		Instantiate (speedPrefab, speedPos, Quaternion.identity);
	}

	void SetUpApple() { 
		Vector3 applePos = new Vector3 (gf.transform.position.x + 5f, 2f, 0f);
		Instantiate (applePrefab, applePos, Quaternion.identity);
	}
}
