using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyController : MonoBehaviour {

	private Transform camera;

	void Start () {
		camera = Camera.main.transform;
	}

	// updates the position of the sky background to follow the camera
	void Update () {
		Vector3 newPos = camera.position;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		transform.position = newPos;
	}
}
