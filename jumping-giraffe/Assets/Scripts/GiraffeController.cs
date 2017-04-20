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
	private bool secondPickup = false;
	private bool secondStar = false;

	private Vector3 newPos;
	private GameObject redDot;
	private GameObject greenDot;

	// Use this for initialization
	void Start () {
		a = GetComponent<Animator> ();
		redDot = GameObject.Find ("redDot");
		greenDot = GameObject.Find ("greenDot");
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
			Debug.Log("Points colliding: " + c.contacts.Length);
			Debug.Log("First point that collided: " + c.contacts[0].point);
			Instantiate (greenDot, c.contacts [0].point, Quaternion.identity);
			JumpByForce ();
		} else { 
			Instantiate (redDot, c.contacts [0].point, Quaternion.identity);
			FlyOff ();
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.CompareTag ("Speed")) {
			if (transformDist < 2f) {
				GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
				transformDist = 4f;
				Invoke ("ReturnTransformDist", 4f);
			} else { 
				secondPickup = true;
				GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
				Invoke ("ReturnTransformDist", 4f);
			}
            
		} 
		else if (other.CompareTag ("Invincibility")) {
			if (invincible) { 
				secondStar = true;
			}
			MakeInvincible ();
			GetComponent<AudioSource> ().PlayOneShot (powerUpSound);
		} 
    }

    void ReturnTransformDist()
    {
		if (secondPickup) { 
			secondPickup = false;
		} else { 
			transformDist = 1.3f;
		}
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
		if (secondStar) { 
			secondStar = false;
		} else { 
			invincible = false;
			a.SetBool ("Invincible", false);
		}
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
