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
//		if (Input.GetKeyDown("space")) 
//			{
//			Debug.Log("Space key pressed.");
//			moveDirection.y = moveSpeed; 
//			float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
//			transform.rotation = 
//				Quaternion.Slerp( transform.rotation, 
//					Quaternion.Euler( 0, 0, targetAngle ), 
//					turnSpeed * Time.deltaTime );
//			}
		moveDirection.y -= gravity * Time.deltaTime;

		if (onGround) { 
			if (Input.GetKeyDown ("space"))
				JumpByForce ();
			else
				JumpByImpulse ();
		}
	}

	void OnCollisionEnter2D(Collision2D c) { 
		onGround = true;
	}

	// the jump that occurs when the user does not hit space
	void JumpByImpulse() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (3.0f * Vector2.up, ForceMode2D.Impulse);
		onGround = false;
	}

	// the jump that the user executes
	void JumpByForce() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (9.8f * Vector2.up, ForceMode2D.Impulse);
		onGround = false;
	}
}
