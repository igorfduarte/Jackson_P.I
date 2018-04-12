using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("LoadingToMenu", 5f);
    }

    void LoadingToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
