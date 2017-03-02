using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeController : MonoBehaviour {

	public float moveSpeed = 8.0f;
	public float turnSpeed;
	public float jumpHeight;
	public float gravity;
	private bool onGround =  false;
	private Vector3 moveDirection = Vector3.zero;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space")) 
			{
			Debug.Log("Space key pressed.");
			moveDirection.y = moveSpeed; 
			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
			transform.rotation = 
				Quaternion.Slerp( transform.rotation, 
					Quaternion.Euler( 0, 0, targetAngle ), 
					turnSpeed * Time.deltaTime );
			}
		moveDirection.y -= gravity * Time.deltaTime;
	}
}
