using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if ((transform.position.x + spriteWidth) < (cameraTransform.position.x - 0.5 * spriteWidth))
        {
            Vector3 newPos = transform.position;
            newPos.x += spriteWidth * 3.0f;
            transform.position = newPos;
        }
    }

    void OnCollisionEnter2D(Collision2D c)
    {

    }
}
