using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {
    [SerializeField] AudioClip coinClip;

    public GameObject steelBoots;
    public GameObject cameraIncrease;
    public GameObject shield;
    public GameObject buyIce;
    public GameObject buyMolotov;
    public GameObject buyHealth;
    public GameObject buyAmmo;
    public GameObject scarL;
    public GameObject vector;
    public GameObject shotgun;
    public GameObject raygun;
    public GameObject glasses;

    [SerializeField] GameObject glassesPrefab;


    public bool hasSteelBoots; // sem uso
    public bool hasCameraIncrease;
    public bool hasShield;
    public bool hasScar;
    public bool hasVector;
    public bool hasShotgun;
    public bool hasRaygun;
    public bool hasGlasses;

    public int goldAtual;
    public int iceCount;
    public int molotovCount;

    Item item;

    GameObject player;
    PlayerHealth playerHealth;
    GameObject weaponObject;
    Weapon weapon;

    ChangeWeapon swapWeapon;
    GameObject weaponHolder;
    AudioSource shopAudio;





    // Use this for initialization
    void Start () {
        shopAudio = GetComponent<AudioSource>();
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        swapWeapon = weaponHolder.GetComponent<ChangeWeapon>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponObject.GetComponent<Weapon>();
    }
	
	// Update is called once per frame
	void Update () {
        

	}
    public void BuyGlasses()
    {
        item = glasses.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            glassesPrefab.SetActive(true);
            hasGlasses = true;
            shopAudio.PlayOneShot(coinClip, 0.5f);
            
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyMolotov()
    {
        item = buyMolotov.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            shopAudio.PlayOneShot(coinClip, 0.5f);
            molotovCount++;
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyShield()
    {
        item = shield.GetComponent<Item>();
        if (goldAtual >= item.itemCost)
        {
            shopAudio.PlayOneShot(coinClip, 0.5f);
            print("era pra ter ativado escudo");
            playerHealth.ActivateShield();
            goldAtual = goldAtual - item.itemCost;
            hasShield = true;
            
            
        }
    }

    public void BuyBootsOFSteel()
    {
        item = steelBoots.GetComponent<Item>();
        if (goldAtual >= item.itemCost)
        {
            shopAudio.PlayOneShot(coinClip, 0.5f);
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
            shopAudio.PlayOneShot(coinClip, 0.5f);
            iceCount++;
            goldAtual = goldAtual - item.itemCost;
        }
    }
    public void BuyHealth()
    {
        item = buyHealth.GetComponent<Item>();
        if (goldAtual >= item.itemCost)
        {
            shopAudio.PlayOneShot(coinClip, 0.5f);
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
            shopAudio.PlayOneShot(coinClip, 0.5f);
            weapon.maxAmmo += 30;
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyScar()
    {
        item = scarL.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            shopAudio.PlayOneShot(coinClip, 0.5f);
            swapWeapon.armas.Add(item.weaponPrefab);
            goldAtual = goldAtual - item.itemCost;
            hasScar = true;
        }
    }

    public void BuyVector()
    {
        item = vector.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            hasVector = true;
            shopAudio.PlayOneShot(coinClip, 0.5f);
            swapWeapon.armas.Add(item.weaponPrefab);
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyShotgun()
    {
        item = shotgun.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            hasShotgun = true;
            shopAudio.PlayOneShot(coinClip, 0.5f);
            swapWeapon.armas.Add(item.weaponPrefab);
            goldAtual = goldAtual - item.itemCost;
        }
    }

    public void BuyRayGun()
    {
        item = raygun.GetComponent<Item>();

        if (goldAtual >= item.itemCost)
        {
            hasRaygun = true;
            shopAudio.PlayOneShot(coinClip, 0.5f);
            swapWeapon.armas.Add(item.weaponPrefab);
            goldAtual = goldAtual - item.itemCost;
        }
    }


}
