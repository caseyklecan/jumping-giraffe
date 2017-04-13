using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleController : MonoBehaviour {
	public float minCreationTime = 45f;
	public float maxCreationTime = 200f;
	public GameObject applePrefab;

	// Use this for initialization
	void Start () {
		Invoke("CreateApple", minCreationTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Giraffe"))
		{
			Destroy(gameObject);
			Invoke("CreateApple", Random.Range(minCreationTime, maxCreationTime));
		}
	}

	void CreateApple()
	{
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = (camera.aspect * camera.orthographicSize * 1.75f) / 2f;
		float yMax = camera.orthographicSize - 1.5f;
		Vector3 speedPos = new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax), Random.Range (-yMax, yMax), applePrefab.transform.position.z);
		Instantiate(applePrefab, speedPos, Quaternion.identity);
		Invoke("CreateApple", Random.Range(minCreationTime, maxCreationTime));
	}
}
	
