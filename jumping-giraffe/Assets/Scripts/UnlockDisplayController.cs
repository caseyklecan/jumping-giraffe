using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockDisplayController : MonoBehaviour {

	public AchievementController achievements;
	public Button pinkGiraffe;
	public Button blueGiraffe;

	// Use this for initialization
	void Start () {
		if (achievements.PinkIsUnlocked ()) {
			pinkGiraffe.interactable = true;
		}
		if (achievements.BlueIsUnlocked ()) { 
			blueGiraffe.interactable = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
