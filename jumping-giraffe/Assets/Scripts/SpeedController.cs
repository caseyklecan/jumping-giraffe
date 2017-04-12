using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour {
    public float minCreationTime = 45f;
    public float maxCreationTime = 200f;
    public GameObject speedPrefab;

	// Use this for initialization
	void Start () {
        Invoke("CreateSpeedPowerUp", minCreationTime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Giraffe"))
        {
            Destroy(gameObject);
			Invoke("CreateSpeedPowerUp", Random.Range(minCreationTime, maxCreationTime));
        }
    }

    void CreateSpeedPowerUp()
    {
        Camera camera = Camera.main;
        Vector3 cameraPos = camera.transform.position;
        float xMax = camera.aspect * camera.orthographicSize;
        float xRange = camera.aspect * camera.orthographicSize * 1.75f;
        float yMax = camera.orthographicSize - 0.5f;
        Vector3 speedPos = new Vector3(cameraPos.x + Random.Range(xMax - xRange, xMax), Random.Range (-yMax, yMax), speedPrefab.transform.position.z);
        Instantiate(speedPrefab, speedPos, Quaternion.identity);
        Invoke("CreateSpeedPowerUp", Random.Range(minCreationTime, maxCreationTime));
    }
}
