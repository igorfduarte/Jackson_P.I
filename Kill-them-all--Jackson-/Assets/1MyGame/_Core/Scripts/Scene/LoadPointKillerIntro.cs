using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPointKillerIntro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Invoke("LoadPoinKillerIntro", 5.5f);
	}

    void LoadPoinKillerIntro()
    {
        SceneManager.LoadScene("PointKillerIntro");
    }
}
