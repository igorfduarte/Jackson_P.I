using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponButton : MonoBehaviour {

    [SerializeField] GameObject scarPrefab;
    [SerializeField] GameObject vectorPrefab;
    [SerializeField] GameObject shotgunPrefab;
    [SerializeField] GameObject raygunPrefab;


    public bool scarL;
    public bool vector;
    public bool shotgun;
    public bool raygun;

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
        if (vector)
        {
            weaponShop.index = 1;
            itemcost = vectorPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
            price.texto = "Item Cost: " + value;
            description.texto = "pistola-metralhadora com baixa precisao e medio alcance. Dano base: 1.5";
            image.sprite = vectorSprite;

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
}
