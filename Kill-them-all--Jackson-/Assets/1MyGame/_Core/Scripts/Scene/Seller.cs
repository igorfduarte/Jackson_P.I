using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour {
    [SerializeField] bool equipShop;
    [SerializeField] bool consuShop;
    GameObject pauseMenuObject;
    PauseMenu pauseMenu;
    public GameObject text;

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
            text.SetActive(true);
             pauseMenu.shopEquip = true;
             pauseMenu.shopConsu = false;
        }
        if (other.gameObject.tag == "Player" && consuShop)
        {
            text.SetActive(true);
            pauseMenu.shopEquip = false;
             pauseMenu.shopConsu = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && equipShop)
        {
            text.SetActive(false);
            pauseMenu.shopEquip = false;
            pauseMenu.shopConsu = false;
        }
        if (other.gameObject.tag == "Player" && consuShop)
        {
            text.SetActive(false);
            pauseMenu.shopConsu = false;
            pauseMenu.shopEquip = false;
        }

    }


}
