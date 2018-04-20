using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Border : MonoBehaviour {

    Animator anim;
    PlayerHealth health;
    GameObject player;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health.isDead)
        {
            StartCoroutine("ActivateBorder");
        }
		
	}

    IEnumerator ActivateBorder()
    {
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("play", true);
    }
}
