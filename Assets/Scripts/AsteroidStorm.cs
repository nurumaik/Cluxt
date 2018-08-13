using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidStorm : MonoBehaviour {

    public GameObject positionMin;
    public GameObject positionMax;

    public GameObject directionStart;
    public GameObject directionEnd1;
    public GameObject directionEnd2;

    public float delay = 1f;
    public float interval = 0.1f;

    public float rotationMin = -20f;
    public float rotationMax = 20f;
    public float velocityMin = 2f;
    public float velocityMax = 7f;
    public float scaleMin = 0.5f;
    public float scaleMax = 2f;

    public bool randomizeDirection = true;

    public GameObject asteroid;

    Vector2 directionMin;
    Vector2 directionMax;

	// Use this for initialization
	void Start () {
        if (randomizeDirection)
        {
            transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        }
        directionMin = directionEnd1.transform.position - directionStart.transform.position;
        directionMax = directionEnd2.transform.position - directionStart.transform.position;
        InvokeRepeating("SpawnAsteroid", delay, interval);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnAsteroid()
    {
        GameObject asteroidClone = Instantiate(asteroid);
        float d = Random.Range(0f, 1f);
        Vector2 direction = (directionMin * d + directionMax * (1 - d)).normalized;
        d = Random.Range(0f, 1f);

        Vector2 position = (positionMin.transform.position * d + positionMax.transform.position * (1 - d));
        asteroidClone.transform.position = position;

        Vector2 newScale = asteroidClone.transform.localScale;
        newScale *= Random.Range(scaleMin, scaleMax);
        asteroidClone.transform.localScale = newScale;

        Rigidbody2D asteroidBody = asteroidClone.GetComponent<Rigidbody2D>();
        asteroidBody.velocity = direction * Random.Range(velocityMin, velocityMax);
        //asteroidBody.AddForce(direction * Random.Range(velocityMin, velocityMax), ForceMode2D.Impulse);
        asteroidBody.angularVelocity = Random.Range(rotationMin, rotationMax);
    }
}
