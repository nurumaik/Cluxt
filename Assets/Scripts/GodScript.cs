using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GodScript : MonoBehaviour {

    public GameObject rip;
    public GameObject win;
    public string nextLevel;
    public bool isfinal = false;

    bool end = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameOver()
    {
        if (end) return;
        end = true;
        Debug.Log("lost");
        rip.SetActive(true);
        Invoke("Reload", 3f);
    }

    public void Win()
    {
        if (end) return;
        end = true;
        if (!isfinal)
        {
            Load();
        }
        else
        {
            Debug.Log("won");
            win.SetActive(true);
            Invoke("Load", 5f);
        }
    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Load()
    {
        SceneManager.LoadScene(nextLevel);
    }

}
