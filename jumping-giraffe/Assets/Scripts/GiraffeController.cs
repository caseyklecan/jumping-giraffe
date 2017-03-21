using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GiraffeController : MonoBehaviour {

	public float transformDist = 1.5f;
	public float jumpForce = 6f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;

	private bool invincible = false;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		// how the giraffe moves
		Vector3 newPos = new Vector3 (transform.position.x + transformDist, transform.position.y, transform.position.z);
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
//			Invoke("Lose", 1.5f);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Speed")) {
			GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
			transformDist = 4f;
			Invoke ("ReturnTransformDist", 4f);
            
		} else if (other.CompareTag ("Invincibility")) {
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
		Animator a = GetComponent<Animator> ();
		a.SetBool ("Flipping", true);
		transformDist = 3f;
		Invoke ("StopFlip", 1.5f);
	}

	void StopFlip() { 
		Animator a = GetComponent<Animator> ();
		a.SetBool ("Flipping", false);
		transformDist = 1.5f;
	}

	void MakeInvincible() { 
		invincible = true;
		Animator a = GetComponent<Animator>();
		a.SetBool ("Invincible", true);
		Invoke("TurnOffInvincibility", 3f);
	}

	void TurnOffInvincibility() { 
		invincible = false;
		Animator a = GetComponent<Animator>();
		a.SetBool ("Invincible", false);
	}

	void FlyOff() { 
		if (!invincible) {
			// want to make this smoother
			Animator a = GetComponent<Animator>();
			a.SetBool ("Dead", true);
			Rigidbody2D rb = GetComponent<Rigidbody2D> ();
			rb.AddForce (1.15f * jumpForce * Vector2.up, ForceMode2D.Impulse);

			Invoke ("Lose", 2f);
		} else { 
			JumpByForce ();
		}
	}

	void Lose() { 
		SceneManager.LoadScene ("loseScene");
	}

	public void Win() { 
		Animator a = GetComponent<Animator>();
		a.SetBool ("Win", true);
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		Invoke ("WinScene", 2f);
	}

	void WinScene() { 
		SceneManager.LoadScene ("winScene");
	}

}
