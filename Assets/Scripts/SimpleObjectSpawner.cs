using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectSpawner : MonoBehaviour {

    public GameObject prefabToSpawn;
    public float interval;
    public float soundInterval;
    public AudioClip spawnSound;

    AudioSource audioSource;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnShit", 0, interval);	
        if (spawnSound)
        {
            audioSource = GetComponent<AudioSource>();
            InvokeRepeating("SoundShit", 0, soundInterval);	
        }
	}

    void SoundShit()
    {
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(spawnSound);
        }
    }

    void SpawnShit ()
    {
        Instantiate(prefabToSpawn, transform.position, Quaternion.identity);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
