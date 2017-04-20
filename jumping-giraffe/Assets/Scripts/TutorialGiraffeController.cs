using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TutorialGiraffeController : MonoBehaviour {

	public float transformDist = 1.5f;
	public float jumpForce = 6f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;

	private Animator a;

	private bool invincible = true;
	private bool dead = false;
	private Vector3 newPos;
	private bool active = false;

	private int section = 0;
//	private bool isFlipping = false;


	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		// how the giraffe moves
		if (!dead) 
			newPos = new Vector3 (transform.position.x + transformDist, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);
	
		if (!active)
			return;

//		if (isFlipping) {
//			Debug.Log ("Rotating 15 on z with rotation: " + -100 * Time.deltaTime);
//			transform.Rotate (0, 0, -100 * Time.deltaTime);
//
//		}

		if (Input.GetKeyDown("space"))
        {
			Flip ();
        }
        else if (Input.touchCount > 0)
        {
          for (int i = 0; i < Input.touchCount; i++)
          {
             if (Input.GetTouch(i).phase == TouchPhase.Moved)
             {
				Flip ();
             }
          }
        }


	}

	void OnCollisionEnter2D(Collision2D c) { 
		Type t = c.collider.GetType ();
		if (t == typeof(UnityEngine.BoxCollider2D)) {
			JumpByForce ();
		} else { 
			FlyOff ();
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Speed")) {
			GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
			transformDist = 4f;
			Invoke ("ReturnTransformDist", 4f);
            
		} 
		else if (other.CompareTag ("Invincibility")) {
			MakeInvincible ();
			GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
		} 
    }

    void ReturnTransformDist()
    {
        transformDist = 1f;
    }

	// the jump that the user executes
	void JumpByForce() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (jumpForce * Vector2.up, ForceMode2D.Impulse);
		AudioSource src = GetComponent<AudioSource> ();
		src.PlayOneShot (bounceSound);
	}

	public void Flip() { 
//		Animator a = GetComponent<Animator> ();
		a.SetBool ("Flipping", true);
		transformDist = 3f;
//		isFlipping = true;
		Invoke ("StopFlip", 1.5f);
	}

	public void StopFlip() { 
		Animator a = GetComponent<Animator> ();
		a.SetBool ("Flipping", false);
//		isFlipping = false;
		transformDist = 1.3f;
	}

	public void MakeInvincible() { 
		invincible = true;
		a.SetBool ("Invincible", true);
		Invoke("TurnOffInvincibility", 3f);
	}

	public void TurnOffInvincibility() { 
		a.SetBool ("Invincible", false);
	}

	public void FlyOff() { 
		if (!invincible) {
			// want to make this smoother
			a.SetBool ("Dead", true);
			dead = true;
			newPos = new Vector3 (transform.position.x, transform.position.y + 10f, transform.position.z);

			Invoke ("ResetPosition", 2.5f);
		} else { 
			JumpByForce ();
		}
	}

	public void ToggleActive() {
		active = !active;
		if (!active)
			section++;
	}

	public int GetSection() {
		return section;
	}

	public void SetNotInvincible() {
		invincible = false;
	}

	public void ResetPosition() { 
		transform.position = new Vector3 (transform.position.x, 2f, 0f);
	}
}
