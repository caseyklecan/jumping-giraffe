using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour {

	private Transform skyCamera;

	void Start () {
		skyCamera = Camera.main.transform;
	}

	// updates the position of the sky background to follow the camera
	void Update () {
		Vector3 newPos = skyCamera.position;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		transform.position = newPos;
	}
}
