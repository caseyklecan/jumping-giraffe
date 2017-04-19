using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GiraffeController : MonoBehaviour {

	public float transformDist = 1.3f;
	public float jumpForce = 6f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;

	private Animator a;
	private bool invincible = false;
	private bool dead = false;
	private Vector3 newPos;

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

	void Flip() { 
		a.SetBool ("Flipping", true);
		transformDist = 3f;
		Invoke ("StopFlip", 1.5f);
	}

	void StopFlip() { 
		a.SetBool ("Flipping", false);
		transformDist = 1.5f;
	}

	void MakeInvincible() { 
		invincible = true;
		a.SetBool ("Invincible", true);
		Invoke("TurnOffInvincibility", 3f);
	}

	void TurnOffInvincibility() { 
		invincible = false;
		a.SetBool ("Invincible", false);
	}

	void FlyOff() { 
		if (!invincible) {
			// want to make this smoother
			a.SetBool ("Dead", true);
			dead = true;
			newPos = new Vector3 (transform.position.x, transform.position.y + 10f, transform.position.z);

			Invoke ("Lose", 2.5f);
		} else { 
			JumpByForce ();
		}
	}

	void Lose() { 
		SceneManager.LoadScene ("loseScene");
	}

	public void Win() { 
		a.SetBool ("Win", true);
		Invoke ("WinScene", 2.5f);
	}

	void WinScene() { 
		SceneManager.LoadScene ("winScene");
	}

}
