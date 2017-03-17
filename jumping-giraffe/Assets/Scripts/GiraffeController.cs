using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiraffeController : MonoBehaviour {

	public float transformDist = 1f;
	public float bounceForce = 4f;
	public float jumpForce = 6f;

	public AudioClip bounceSound;
    public AudioClip powerUpSound;


	private bool onGround =  false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// how the giraffe moves
		Vector3 newPos = new Vector3 (transform.position.x + transformDist, transform.position.y, transform.position.z);
		transform.position = Vector3.Lerp (transform.position, newPos, Time.deltaTime);


		if (onGround) { 
			if (Input.GetKeyDown ("space")) {
				JumpByForce ();
			}
            else if (Input.touchCount > 0) {
				for (int i = 0; i < Input.touchCount; i++) { 
					if (Input.GetTouch (i).phase == TouchPhase.Moved) { 
						// swipe
					} else if (Input.GetTouch(i).phase == TouchPhase.Began) { 
						JumpByForce ();
					}
				}
			} else {
				JumpByImpulse ();
			}

			AudioSource src = GetComponent<AudioSource> ();
			src.PlayOneShot (bounceSound);


		}


	}

	void OnCollisionEnter2D(Collision2D c) { 
		onGround = true;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Speed"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerUpSound);
            // this is working but it still needs to be fixed...
            // it works weirdly when you hit a speed power up then hit another one before you're done
            // speeding up from the other one
            transformDist = 4f;
            Invoke("ReturnTransformDist", 4f);
            
        }
        else if (other.CompareTag("Invincibility"))
        {
            GetComponent<AudioSource>().PlayOneShot(powerUpSound);
        }
    }

    void ReturnTransformDist()
    {
        transformDist = 1f;
    }

	// the jump that occurs when the user does not hit space
	void JumpByImpulse() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (bounceForce * Vector2.up, ForceMode2D.Impulse);
		onGround = false;
	}

	// the jump that the user executes
	void JumpByForce() { 
		Rigidbody2D rb = GetComponent<Rigidbody2D> ();
		rb.AddForce (jumpForce * Vector2.up, ForceMode2D.Impulse);
		onGround = false;
	}

}
