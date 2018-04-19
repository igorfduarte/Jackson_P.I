using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopButton : MonoBehaviour {
   
    
    Shop shop;
    GameObject shopObject;
    GameObject player;
    PlayerHealth health;
   
    ScoreManager scoreClass;
    [SerializeField] GameObject score;

    bool hasScar;
    bool hasVector;
    bool hasShotgun;
    bool hasRaygun;
    bool hasBoots;
    bool hasShield;
    bool hasGlasses;


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
        if (index == 1 && !hasVector)
        {
            shop.BuyVector();
            hasVector = true;
        }

        if (index == 2 && !hasScar)
        {
            shop.BuyScar();
            hasScar = true;
        }

        if (index == 3 && !hasShotgun)
        {
            shop.BuyShotgun();
            hasShotgun = true;
        }

        if (index == 4 && !hasRaygun)
        {
            shop.BuyRayGun();
            hasRaygun = true;
        }
        if (index == 5 )
        {
            shop.BuyIce();
            
        }
        if (index == 6)
        {
            shop.BuyMolotov();


        }
        if (index == 7 )
        {
            shop.BuyHealth();
            
        }
        if (index == 8)
        {
            shop.BuyAmmo();
            scoreClass = score.GetComponent<ScoreManager>();
            scoreClass.UpdateAmmoHUD();
        }
        if (index == 9 && !hasBoots)
        {
            hasBoots = true;
            shop.BuyBootsOFSteel();

        }
        if (index == 10 && !hasShield)
        {
            hasShield = true;
            shop.BuyShield();

        }
        if (index == 11 && !hasGlasses)
        {
            hasGlasses = true;
            print("glasses");

        }



    }
}
