using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GiraffeController : MonoBehaviour {

	public float transformDist = 1.5f;
	public float bounceForce = 4f;
	public float jumpForce = 6f;
	public float yDist = 0f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;

	private bool invincible = false;


	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		// how the giraffe moves
		Vector3 newPos = new Vector3 (transform.position.x + transformDist, transform.position.y + yDist, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);

//
//		if (onGround) { 
//			if (Input.GetKeyDown ("space")) {
//				JumpByForce ();
//			}
//            else if (Input.touchCount > 0) {
//				for (int i = 0; i < Input.touchCount; i++) { 
//					if (Input.GetTouch (i).phase == TouchPhase.Moved) { 
//						// swipe
//                        // i used swipe for the giraffe flip
//                        // lmk if you want me to use something else and we can change it
//					} else if (Input.GetTouch(i).phase == TouchPhase.Began) { 
//						JumpByForce ();
//					}
//				}
//			} else {
//				JumpByImpulse ();
//			}



//		}

//        if (!onGround)
//        {
//            if (Input.GetKeyDown("space"))
//            {
//                GetComponent<Animator>().SetTrigger("FlipTrigger");
//            }
//            else if (Input.touchCount > 0)
//            {
//                for (int i = 0; i < Input.touchCount; i++)
//                {
//                    if (Input.GetTouch(i).phase == TouchPhase.Moved)
//                    {
//                        GetComponent<Animator>().SetTrigger("FlipTrigger");
//                    }
//                }
//            }
//        }


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

	void MakeInvincible() { 
		invincible = true;
		// animation for colors
		Invoke("TurnOffInvincibility", 3f);
	}

	void TurnOffInvincibility() { 
		invincible = false;
	}

	void FlyOff() { 
		if (!invincible) {
			transformDist = 4f;
			yDist = 3f;
			Invoke ("Lose", 2f);
		} else { 
			JumpByForce ();
		}
	}

	void Lose() { 
		SceneManager.LoadScene ("loseScene");
	}

}
