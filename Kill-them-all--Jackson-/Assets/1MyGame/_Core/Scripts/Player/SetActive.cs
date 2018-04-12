using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActive : MonoBehaviour {

    PlayerMovement playerMove;
    GameObject player;
    public GameObject poison;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMove = player.GetComponent<PlayerMovement>();
        

    }
	
	// Update is called once per frame
	void Update () {

        if (playerMove.isSlow)
        {
            
            poison.SetActive(true);
            CancelInvoke("StopPoisonEffect");
            
        }
        if (!playerMove.isSlow)
        {
            StopPoisonEffect();
        }
		
	}

    void StopPoisonEffect()
    {
        poison.SetActive(false);
    }
}
