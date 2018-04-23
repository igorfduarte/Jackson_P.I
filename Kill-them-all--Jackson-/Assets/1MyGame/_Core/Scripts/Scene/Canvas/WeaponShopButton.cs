using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopButton : MonoBehaviour {
   
    
    Shop shop;
    GameObject shopObject;
    GameObject player;
    AudioSource shopSource;
    PlayerHealth health;
   
    ScoreManager scoreClass;
    [SerializeField] GameObject score;





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
        if (index == 1 && !shop.hasVector)
        {
            
            shop.BuyVector();
            
        }

        if (index == 2 && !shop.hasScar)
        {
           
            shop.BuyScar();
            
        }

        if (index == 3 && !shop.hasShotgun)
        {
         
            shop.BuyShotgun();
            
        }

        if (index == 4 && !shop.hasRaygun)
        {
           
            shop.BuyRayGun();
            
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
        if (index == 9 && !shop.hasSteelBoots)
        {
          
            
            shop.BuyBootsOFSteel();

        }
        if (index == 10 && !shop.hasShield)
        {
           
            
            shop.BuyShield();

        }
        if (index == 11 && !shop.hasGlasses)
        {

            shop.BuyGlasses();
            

        }



    }
}
