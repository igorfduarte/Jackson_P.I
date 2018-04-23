using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glasses : MonoBehaviour {

    GameObject player;
    SpriteRenderer glassSprite;
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        glassSprite = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        if (player.GetComponent<SpriteRenderer>().flipX )
        {
            glassSprite.flipX = true;
            transform.position = pos2.position;

        }
        else
        {
            transform.position = pos1.position;
            glassSprite.flipX = false;
        }

	}
}
