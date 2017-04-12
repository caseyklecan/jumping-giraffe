using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibilityController : MonoBehaviour {

	public float minCreationTime = 5f;
	public float maxCreationTime = 60f;
	public GameObject invincibilityPrefab;

	// Use this for initialization
	void Start () {
		Invoke("CreateInvincibilityPowerUp", minCreationTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Giraffe"))
        {
            Destroy(gameObject);
			Invoke ("CreateInvincibilityPowerUp", Random.Range (minCreationTime, maxCreationTime));
        }
    }

	void CreateInvincibilityPowerUp() { 
		Camera camera = Camera.main;
		Vector3 cameraPos = camera.transform.position;
		float xMax = camera.aspect * camera.orthographicSize;
		float xRange = (camera.aspect * camera.orthographicSize * 1.75f) / 2f ;
		float yMax = camera.orthographicSize - 1.5f;
		Vector3 invPos = new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax), Random.Range (-yMax, yMax), invincibilityPrefab.transform.position.z);
		Instantiate(invincibilityPrefab, invPos, Quaternion.identity);
		Invoke("CreateInvincibilityPowerUp", Random.Range(minCreationTime, maxCreationTime));

	}
}
