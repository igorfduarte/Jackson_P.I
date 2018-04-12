using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour {
    [SerializeField] bool equipShop;
    [SerializeField] bool consuShop;
    GameObject pauseMenuObject;
    PauseMenu pauseMenu;

    // Use this for initialization
    void Start () {
        pauseMenuObject = GameObject.FindGameObjectWithTag("PauseCanvas");
        pauseMenu = pauseMenuObject.GetComponent<PauseMenu>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && equipShop)
        {
             pauseMenu.shopEquip = true;
             pauseMenu.shopConsu = false;
        }
        if (other.gameObject.tag == "Player" && consuShop)
        {
             pauseMenu.shopEquip = false;
             pauseMenu.shopConsu = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && equipShop)
        {
             pauseMenu.shopEquip = false;
            pauseMenu.shopConsu = false;
        }
        if (other.gameObject.tag == "Player" && consuShop)
        {
             pauseMenu.shopConsu = false;
            pauseMenu.shopEquip = false;
        }

    }


}
