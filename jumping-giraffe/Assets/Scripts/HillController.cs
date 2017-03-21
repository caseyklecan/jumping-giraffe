using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HillController : MonoBehaviour {

    private Transform cameraTransform;
    private float spriteWidth;
    private SpriteRenderer spriteRenderer;
    public Collider2D coll;

    // Use this for initialization
    void Start()
    {
        cameraTransform = Camera.main.transform;
        spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
        spriteWidth = spriteRenderer.sprite.bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.x + spriteWidth) < (cameraTransform.position.x - 0.75 * spriteWidth))
        {
            Vector3 newPos = transform.position;
            newPos.x += spriteWidth * 4.0f;
			newPos.y = 0.75f;
            transform.position = newPos;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "Giraffe")
        {
            coll = GetComponent<Collider2D>();
           if (coll.GetType() == typeof(EdgeCollider2D))
            {
                //SceneManager.LoadScene("loseScene");
//                Debug.Log(coll.GetType());
				Debug.Log("Giraffe hit edge");
            }
            else
            {
                Debug.Log(coll.GetType());
            }
        }
    }

//    void OnTriggerEnter2D(Collider2D c)
//    {
//        if (c.gameObject.tag == "Giraffe")
//        {
//            Debug.Log("hit the box collider");
//        }
//    }
}
