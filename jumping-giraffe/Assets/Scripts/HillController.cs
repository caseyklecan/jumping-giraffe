using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HillController : MonoBehaviour {

//	public Collider2D coll;
//	public GameObject otherHill1Prefab;
	public GameObject otherHill2Prefab;
    private float spriteWidth;
	private float spriteHeight;

	private Transform cameraTransform;
    private SpriteRenderer spriteRenderer;
	private Color[] colors;
	private float[] hillSizes = { 1f, 1.5f, 2.5f, 3.5f }; 
	private float[] hillHeights = { 1f, 1.25f, 1.5f, 1.75f, 2.0f };
	private int currentSize, currentHeight;

    

    // Use this for initialization
    void Start()
	{
		cameraTransform = Camera.main.transform;
		spriteRenderer = GetComponent<Renderer> () as SpriteRenderer;
		spriteWidth = spriteRenderer.sprite.bounds.size.x;
		spriteHeight = spriteRenderer.sprite.bounds.size.y;
		currentSize = 1;
		currentHeight = 2;

		colors = new Color[4];
		colors[0] = new Color(1f, 1f, 1f);
		colors [1] = new Color (.5f, .9f, 1f);
		colors [2] = new Color (.65f, 1f, 1f);
		colors [3] = new Color (.7f, 1f, .85f);
   	 }

    // if we're far enough off screen, can move our current hill, change its color/size appropriately
    void Update()
    {
		if ((transform.position.x + spriteWidth) < (cameraTransform.position.x - 0.75 * spriteWidth))
        {
			int index = Random.Range (0, colors.Length);
			spriteRenderer.color = colors [index];
			currentSize = Random.Range (0, hillSizes.Length);
			currentHeight = Random.Range (0, hillHeights.Length);
			Vector3 newPos = transform.position;
			newPos.x = otherHill2Prefab.transform.position.x + (0.5f * spriteWidth * otherHill2Prefab.gameObject.GetComponent<HillController> ().GetScale ()) + (0.5f * spriteWidth * hillSizes [currentSize]);
			newPos.y = (-1f * Camera.main.orthographicSize) + ((spriteHeight * hillHeights [currentHeight]) / 2f);

			transform.position = newPos;
			transform.localScale = new Vector3(hillSizes [currentSize], 1.5f, 1.0f);
			transform.localScale = new Vector3(hillSizes [currentSize], hillHeights[currentHeight], 1.0f);
        }
    }

	float GetScale() { 
		return hillSizes[currentSize];
	}
		
}
