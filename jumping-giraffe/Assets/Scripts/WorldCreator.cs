using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldCreator : MonoBehaviour {

	private Transform cam;
	private float spriteWidth;

	// Use this for initialization
	void Start () {
		cam = Camera.main.transform;

		SpriteRenderer spriteRenderer = gameObject.GetComponent<Renderer>() as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
	}
	
	// Update is called once per frame
	void Update () {
		if( (transform.position.x + spriteWidth) < cam.position.x) {
			Vector3 newPos = transform.position;
			newPos.x += 2.0f * spriteWidth; 
			transform.position = newPos;
		}
	}
}
