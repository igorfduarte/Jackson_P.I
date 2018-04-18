using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour {
    [SerializeField]bool isShield;
    [SerializeField] bool isBoots;
    [SerializeField] bool isGlasses;
    [SerializeField] bool isIce;
    [SerializeField] bool isHealth;
    [SerializeField] bool isAmmo;
    [SerializeField] bool isMolotov;
    [SerializeField] bool isScarL;
    Shop shop;
    GameObject shopObject;
    GameObject player;
    PlayerHealth health;
    [SerializeField] GameObject score;
    ScoreManager scoreClass;
    bool hasBoots;
    bool hasShield;
    bool hasScar;

	// Use this for initialization
	void Start () {
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        


    }
	
	// Update is called once per frame
	void Update () {

	}

    public void OnClick()
    {
        if (isShield && !hasShield)
        {
            
            shop.BuyShield();
            hasShield = true;

        }
        if (isBoots && !hasBoots)
        {
            hasBoots = true;
            shop.BuyBootsOFSteel();

        }
        if (isGlasses)
        {
            // buy glasses function
        }
        if (isIce)
        {
            shop.BuyIce();
            // buy glasses function
        }
        if (isHealth)
        {
            shop.BuyHealth();

            // buy glasses function
        }
        if (isAmmo)
        {
            
            scoreClass = score.GetComponent<ScoreManager>();
            shop.BuyAmmo();
            scoreClass.UpdateAmmoHUD();
            
            // buy glasses function
        }
        if (isMolotov)
        {
            shop.BuyMolotov();
        }
       


    }

    
}
