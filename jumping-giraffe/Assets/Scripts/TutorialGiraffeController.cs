using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class TutorialGiraffeController : MonoBehaviour {

	// TODO add red/green dot logic, then this is good to go

	public float transformDist = 1.3f;
	public float jumpForce = 6f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;

	private Animator a;
	private bool invincible = true;
	private bool dead = false;
	private Vector3 newPos;
	private bool active = false;
	private int section = 0;


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
        transformDist = 1.3f;
    }

	// the jump that the user executes
	void JumpByForce() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (jumpForce * Vector2.up, ForceMode2D.Impulse);
		AudioSource src = GetComponent<AudioSource> ();
		src.PlayOneShot (bounceSound);
	}

	public void Flip() { 
		a.SetBool ("Flipping", true);
		transformDist = 3f;
		Invoke ("StopFlip", 1.5f);
	}

	public void StopFlip() { 
		a.SetBool ("Flipping", false);
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
