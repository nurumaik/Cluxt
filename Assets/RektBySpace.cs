using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RektBySpace : MonoBehaviour {

    public float life = 2f;
    public bool inSpace = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (inSpace)
        {
            life -= Time.deltaTime;
        }
        if (life <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("space"))
        {
            inSpace = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("space"))
        {
            inSpace = true;
        }
    }
}
