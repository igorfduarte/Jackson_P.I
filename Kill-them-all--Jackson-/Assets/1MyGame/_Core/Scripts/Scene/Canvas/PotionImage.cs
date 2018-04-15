using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionImage : MonoBehaviour {

    

    [SerializeField] Sprite icePotion;
    [SerializeField] Sprite molotovPotion;

    GameObject player;
    Tiro tiro;
    Image image;


    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        tiro = player.GetComponent<Tiro>();       
        image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if (tiro.molotovActive)
        {
            image.sprite = molotovPotion;
        }
        if (tiro.icePotionActive)
        {
            image.sprite = icePotion;
        }


	}
}
