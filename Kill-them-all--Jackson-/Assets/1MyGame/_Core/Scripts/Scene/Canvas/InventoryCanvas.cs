using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCanvas : MonoBehaviour {
    public GameObject skillPanel;
    bool isInPanel = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.K) && isInPanel == false)
        {
            skillPanel.SetActive(true);
            Debug.Log("painel de skill");
            isInPanel = true;           
            Time.timeScale = 0f;
        }
        if (Input.GetKeyDown(KeyCode.K) && isInPanel == true)
        {
            isInPanel = false;
            skillPanel.SetActive(false);
            Time.timeScale = 1f;
        }
	}
}
