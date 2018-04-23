using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    GameObject player;
    PlayerHealth playerHealth;
    Animator anim;
    GameObject shopObject;
    Shop shop;
    [SerializeField] bool camera1;



	// Use this for initialization
	void Start () {
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();

	}
	
	// Update is called once per frame
	void Update () {
        if (playerHealth.currentHealth<=0)
        {
            anim.SetBool("dead", true);
        }
        if (shop.hasGlasses && camera1)
        {
            this.gameObject.SetActive(false);
        }
	}
}
