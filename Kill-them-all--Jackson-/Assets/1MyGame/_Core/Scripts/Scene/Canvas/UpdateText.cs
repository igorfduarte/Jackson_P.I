using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateText : MonoBehaviour {

    public float value;
    Text text;

    [SerializeField] GameObject shieldPrefab;
    [SerializeField] GameObject steelBootsPrefab;
    [SerializeField] GameObject glassesPrefab;
    [SerializeField] GameObject icePotionPrefab;
    [SerializeField] GameObject healthPrefab;
    [SerializeField] GameObject ammoPrefab;
    Shop shop;
    [SerializeField] string texto;
     Item itemcost;


    [SerializeField] bool shield;
    [SerializeField] bool steelBoots;
    [SerializeField] bool glasses;
    [SerializeField] bool icePotion;
    [SerializeField] bool health;
    [SerializeField] bool ammo;


    void Start()
    {
        if (shield)
        {
            
            itemcost = shieldPrefab.GetComponent<Item>();
            value = itemcost.itemCost;
        }
        if (steelBoots)
        {

            itemcost = steelBootsPrefab.GetComponent<Item>();
            value = itemcost.itemCost;

        }
        if (glasses)
        {

            itemcost = glassesPrefab.GetComponent<Item>();
            value = itemcost.itemCost;

        }
        if (icePotion)
        {

            itemcost = icePotionPrefab.GetComponent<Item>();
            value = itemcost.itemCost;

        }
        if (health)
        {

            itemcost = healthPrefab.GetComponent<Item>();
            value = itemcost.itemCost;

        }
        if (ammo)
        {

            itemcost = ammoPrefab.GetComponent<Item>();
            value = itemcost.itemCost;

        }


        text = GetComponent<Text>();
        text.text = texto + value;

    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
}
