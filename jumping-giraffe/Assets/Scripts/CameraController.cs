using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private Transform giraffe;

	// Use this for initialization
	void Start () {
		giraffe = GameObject.Find ("Giraffe").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = giraffe.position;
		newPos.y = transform.position.y;
		newPos.z = transform.position.z;
		transform.position = newPos;
	}
}
