using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour {

    public float gravity = 1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Rigidbody2D body in Object.FindObjectsOfType<Rigidbody2D>())
        {
            if (body.CompareTag("SpaceShip") || body.CompareTag("Bouncer"))
                continue;
            Vector3 delta = (transform.position - (Vector3)body.position);
            body.AddForce(delta / (delta.magnitude * delta.magnitude) * gravity * Time.deltaTime * body.mass, ForceMode2D.Impulse);
        }
	}
}
