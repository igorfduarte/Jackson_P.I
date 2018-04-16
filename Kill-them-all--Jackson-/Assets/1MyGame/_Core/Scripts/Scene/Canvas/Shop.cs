using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public GameObject steelBoots;
    public GameObject cameraIncrease;
    public GameObject shield;
    public GameObject buyIce;
    public GameObject buyMolotov;
    public GameObject buyHealth;
    public GameObject buyAmmo;

    public bool hasSteelBoots; // sem uso
    public bool hasCameraIncrease;
    public bool hasShield;

    public int goldAtual;
    public int iceCount;
    public int molotovCount;

    Item item;

    GameObject player;
    PlayerHealth playerHealth;
    GameObject weaponObject;
    Weapon weapon;






    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponObject.GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
		

	}
    public void BuyMolotov()
    {
        item = buyMolotov.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            molotovCount++;
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyShield()
    {
        item = shield.GetComponent<Item>();
        if (goldAtual >= item.itemCost && !hasShield)
        {
            print("era pra ter ativado escudo");
            playerHealth.ActivateShield();
            goldAtual = goldAtual - item.itemCost;
            
            
        }
    }

    public void BuyBootsOFSteel()
    {
        item = steelBoots.GetComponent<Item>();
        if (goldAtual >= item.itemCost && !hasSteelBoots)
        {
            hasSteelBoots = true;
            playerHealth.hasSteelBoots = true;
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyIce()
    {
        item = buyIce.GetComponent<Item>();
        
        if (goldAtual >= item.itemCost )
        {
            iceCount++;
            goldAtual = goldAtual - item.itemCost;
        }
    }
    public void BuyHealth()
    {
        item = buyHealth.GetComponent<Item>();
        if (goldAtual >= item.itemCost)
        {
            playerHealth.currentHealth += 10;
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyAmmo()
    {
        weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponObject.GetComponent<Weapon>();
        item = buyAmmo.GetComponent<Item>();
        if (goldAtual >= item.itemCost)
        {
             weapon.maxAmmo += 30;
            goldAtual = goldAtual - item.itemCost;
        }
    }


}
