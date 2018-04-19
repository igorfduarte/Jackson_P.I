using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSprite : MonoBehaviour {

    GameObject weapon;

    SpriteRenderer selectedWeaponSprite;

    Image currentSprite;

	// Use this for initialization
	void Start () {
        currentSprite = GetComponent<Image>();

	}
	
	// Update is called once per frame
	void Update () {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        selectedWeaponSprite = weapon.GetComponent<SpriteRenderer>();
        currentSprite.sprite = selectedWeaponSprite.sprite;

		
	}
}
