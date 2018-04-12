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
    Shop shop;
    [SerializeField] string texto;
     Item itemcost;


    [SerializeField] bool shield;
    [SerializeField] bool steelBoots;
    [SerializeField] bool glasses;


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


        text = GetComponent<Text>();
        text.text = texto + value;

    }

    // Update is called once per frame
    void Update()
    {

        
        
    }
}
