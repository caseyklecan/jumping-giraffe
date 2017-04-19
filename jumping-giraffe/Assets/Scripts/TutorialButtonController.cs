using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonController : MonoBehaviour {

	public TutorialGiraffeController gf;
	public Text description;
	public Text buttonText;

	private string tryText, gotItText, describeJump, describeDeath, describeStar, describeSpeed, describeApple, describeWin;
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

			break;
		case 2:
			description.text = describeStar;

			break;
		case 3:
			description.text = describeApple;

			break;
		case 5: 
			description.text = describeWin;

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
		gf.ResetPosition ();
	}

	void SetUpStar() {

	}

	void SetUpSpeed() { 

	}

	void SetUpApple() { 

	}
}
