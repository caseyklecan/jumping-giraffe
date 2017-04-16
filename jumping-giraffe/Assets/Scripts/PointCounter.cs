using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PointCounter : MonoBehaviour {
	private float time;
	private Text appleGT;
	GameObject appleGO;

	// Use this for initialization
	void Start () {
		appleGO = GameObject.Find ("AppleCounter");
		appleGT = appleGO.GetComponent<Text> ();
		appleGT.text = "0";
		time = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;
		appleGT.text = time.ToString();
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag("Apple"))
		{
			time += 10.0f;
		}
	}
}
