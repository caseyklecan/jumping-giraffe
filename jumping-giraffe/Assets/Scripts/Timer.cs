using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour {

	public float time;
	private Text timerGT;
	GameObject timerGO;

	// Use this for initialization
	void Start () {
		timerGO = GameObject.Find ("Timer");
		timerGT = timerGO.GetComponent<Text> ();
		timerGT.text = "30.0";
		time = 30.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		timerGT.text = time.ToString();
		if (time < 0.0f) {
			//timerGO.GetComponent<GiraffeController> ().Win ();
		}
	}
}
