using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float time;
	private int timeInt;
	private Text timerGT;
	GameObject timerGO;

	// Use this for initialization
	void Start () {
		timerGO = GameObject.Find ("Timer");
		timerGT = timerGO.GetComponent<Text> ();
		timerGT.text = "30";
		time = 30;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		timeInt = (int)time;
		timerGT.text = "Time: " + timeInt.ToString();
		if (time < 0) {
			//timerGO.GetComponent<GiraffeController> ().Win ();
		}
	}
}
