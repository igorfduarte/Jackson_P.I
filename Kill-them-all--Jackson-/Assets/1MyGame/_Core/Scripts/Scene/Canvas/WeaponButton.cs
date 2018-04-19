using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour {

    [SerializeField] GameObject scarPrefab;
    [SerializeField] GameObject vectorPrefab;
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject raygunPrefab;
    [SerializeField] GameObject icePotionPrefab;
    [SerializeField] GameObject mollyPrefab;
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject ammoPrefab;
    [SerializeField] GameObject bootsPrefab;
    [SerializeField] GameObject shieldPrefab;
    [SerializeField] GameObject glassesPrefab;


    public bool scarL;
    public bool vector;
    public bool shotgun;
    public bool raygun;
    public bool icePotion;
    public bool molotov;
    public bool health;
    public bool ammo;
    public bool boots;
    public bool shield;
    public bool glasses;

    GameObject itemDescription;
    GameObject weaponImage;
    GameObject weaponPrices;
    GameObject shopWeapon;


    ItemDescription description;
    WeaponPrices price;
    Image image;
    Item itemcost;
    WeaponShopButton weaponShop;



    public Sprite scarSprite;
    public Sprite vectorSprite;
    public Sprite shotgunSprite;
    public Sprite raygunSprite;
    public Sprite selectedSprite;
    public Sprite iceSprite;
    public Sprite mollySprite;
    public Sprite healthSprite;
    public Sprite ammoSprite;
    public Sprite bootsSprite;
    public Sprite shieldSprite;
    public Sprite glassesSprite;


    int value;
    public int index;
      



    private void Start()
    {
        shopWeapon = GameObject.FindGameObjectWithTag("WeaponShop");
        weaponShop = shopWeapon.GetComponent<WeaponShopButton>();

        weaponImage = GameObject.FindGameObjectWithTag("WeaponImage");
        itemDescription = GameObject.FindGameObjectWithTag("Description");
        weaponPrices = GameObject.FindGameObjectWithTag("WeaponPrices");
        price = weaponPrices.GetComponent<WeaponPrices>();
        description = itemDescription.GetComponent<ItemDescription>();
        image = weaponImage.GetComponent<Image>();

    }

    public void OnClick()
    {
        Weapon();
        Item();
        Armory();
    }

    public void Weapon()
    {
        if (vector)
        {
            weaponShop.index = 1;
            itemcost = vectorPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "pistola-metralhadora com baixa precisao e medio alcance. Dano base: 1.5";
            image.sprite = vectorSprite;

        }

        if (scarL)
        {

            weaponShop.index = 2;
            selectedSprite = scarSprite;
            description.texto = "Rifle automatico de alta precisao e longo alcance. Dano base: 1.75";

            itemcost = scarPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            image.sprite = scarSprite;

        }
        
        if (shotgun)
        {
            weaponShop.index = 3;
            itemcost = shotgunPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "Arma destruidora de curto alcance. Dano base: 5";
            image.sprite = shotgunSprite;

        }
        if (raygun)
        {
            weaponShop.index = 4;
            itemcost = raygunPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "Dispara projeteis que ricocheteiam paredes e atravessam inimigos. Dano base: 2.5 ";
            image.sprite = raygunSprite;

        }
    }

    public void Item()
    {
        if (icePotion)
        {

            weaponShop.index = 5;
            selectedSprite = iceSprite;
            description.texto = "Congela inimigos em uma área por um curto periodo de tempo";

            itemcost = icePotionPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            image.sprite = iceSprite;

        }
        if (molotov)
        {
            weaponShop.index = 6;
            itemcost = mollyPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "Clássica molotov";
            image.sprite = mollySprite;

        }
        if (health)
        {
            weaponShop.index = 7;
            itemcost = healthPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "+ 10 para vida atual";
            image.sprite = healthSprite;

        }
        if (ammo)
        {
            weaponShop.index = 8;
            itemcost = ammoPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "+30 de muniçao para a arma atual";
            image.sprite = ammoSprite;

        }
    }

    public void Armory()
    {
        if (boots)
        {

            weaponShop.index = 9;
            selectedSprite = bootsSprite;
            description.texto = "Imunidade a armadilhas de espinho";

            itemcost = bootsPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            image.sprite = bootsSprite;

        }
        if (shield)
        {
            weaponShop.index = 10;
            itemcost = shieldPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "Protege o jogador. Some depois de um hit. Tempo de recarga: 10seg";
            image.sprite = shieldSprite;

        }
        if (glasses)
        {
            weaponShop.index = 11;
            itemcost = glassesPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "Aumenta o campo de visao";
            image.sprite = glassesSprite;

        }
       
    }
}
