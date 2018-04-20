using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {
    GameObject player;
    PlayerHealth playerHealth;
    Animator anim;



	// Use this for initialization
	void Start () {
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
	}
}
