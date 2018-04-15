using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour {

    GameObject shopObject;
    Shop shop;
    public int goldAmount;


	// Use this for initialization
	void Start () {
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        Destroy(gameObject, 60);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            shop.goldAtual += goldAmount;
            Destroy(gameObject);
        }
    }



    
}
