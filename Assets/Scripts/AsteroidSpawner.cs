using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {

	// Use this for initialization
	void Start () {
        /*
        Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 180));
        transform.localRotation = rotation;
        GetComponent<Rigidbody2D>().velocity = rotation * new Vector2(Math.SomewhatNormal(0, 0.5f, 100) - 0.25f, 0);
        Vector2 newScale = transform.localScale;
        newScale.x *= Random.Range(0.5f, 2f);
        newScale.y *= Random.Range(0.5f, 2f);
        transform.localScale = newScale;
        GetComponent<Rigidbody2D>().angularVelocity = Random.Range(0, 20f);
        */
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
