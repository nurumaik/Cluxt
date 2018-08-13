using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipController : MonoBehaviour {

    public float rotationSpeed = 60f;

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody2D>().angularVelocity = rotationSpeed;	
	}
	
	// Update is called once per frame
	void Update () {
        //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
	}
}
