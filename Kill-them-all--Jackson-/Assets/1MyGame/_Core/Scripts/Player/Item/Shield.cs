using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour {
    GameObject player;
    SpriteRenderer spritePlayer;
    [SerializeField] GameObject pos1;
    [SerializeField] GameObject pos2;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {
        spritePlayer = player.GetComponent<SpriteRenderer>();
        if (spritePlayer.flipX)
        {
            transform.position = pos2.transform.position;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (!spritePlayer.flipX)
        {
            transform.position = pos1.transform.position;
            this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

	}
}
