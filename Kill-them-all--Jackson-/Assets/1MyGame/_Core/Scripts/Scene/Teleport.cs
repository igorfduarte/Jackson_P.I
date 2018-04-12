using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour {
    
    GameObject player;
    [SerializeField] bool isWave;
    [SerializeField] bool isShop;
    public bool isInWaveTeleport;
    public bool isInShopTeleport;



    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && isWave)
        {
            
            isInWaveTeleport = true;
        }

        if (other.gameObject.tag == "Player" && isShop)
        {
            
            isInShopTeleport = true;
        }
    }

   
}
