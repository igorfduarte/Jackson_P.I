using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopButton : MonoBehaviour {
   
    
    Shop shop;
    GameObject shopObject;
    GameObject player;
    PlayerHealth health;
   
    ScoreManager scoreClass;
  
    bool hasScar;
    bool hasVector;
    bool hasShotgun;
    bool hasRaygun;


    WeaponShopButton weaponShop;
    public int index;

    // Use this for initialization
    void Start () {
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
    }
	
	// Update is called once per frame
	
    public void OnClick()
    {
        if (index == 4 && !hasRaygun)
        {
            shop.BuyRayGun();
            hasRaygun = true;
        }
        if (index == 3 && !hasShotgun)
        {
            shop.BuyShotgun();
            hasShotgun = true;
        }
        if (index == 2 && !hasScar)
        {
            shop.BuyScar();
            hasScar = true;
        }
        if (index == 1 && !hasVector)
        {
            shop.BuyVector();
            hasVector = true;
        }
    }
}
