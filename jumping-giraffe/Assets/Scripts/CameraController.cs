using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform giraffe;
	public GiraffeController gf;

	private float timeLeft = 45f;

	void Start () {
		giraffe = GameObject.Find ("Giraffe").transform;
	}
	
	// updates the position of the camera to follow the giraffe
	void Update () {
		Vector3 newPos = giraffe.position;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		transform.position = newPos;

		timeLeft -= Time.deltaTime;
		if (timeLeft < 0) { 
			gf.Win ();
		}
	}
}
