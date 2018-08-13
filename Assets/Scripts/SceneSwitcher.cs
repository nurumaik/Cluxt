using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

    public string sceneToLoad;

	// Use this for initialization
	void Start () {
    //    Invoke("LoadGame", 2.5f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadGame();
        }
	}

    void LoadGame()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
