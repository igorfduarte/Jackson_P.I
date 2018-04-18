using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnManager : MonoBehaviour {

    

    [SerializeField] int index;
    [SerializeField] GameObject weaponPrefab;
    HudWeapon hudWeapon;
    GameObject weapon;
    GameObject weaponHolder;
    ChangeWeapon swapWeapon;


	// Use this for initialization
	void Start () {
        weapon = GameObject.FindGameObjectWithTag("HUDWeapon");
        hudWeapon = weapon.GetComponent<HudWeapon>();
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHolder");
        swapWeapon = weaponHolder.GetComponent<ChangeWeapon>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            swapWeapon.armas.Add(weaponPrefab);

            Condition();

            this.gameObject.SetActive(false);

        }
    }

    void Condition()
    {
        if (index == 1 )
        {
            hudWeapon.hasAk = true;
        }
        if (index == 2)
        {
            hudWeapon.hasVector = true;
        }
        if (index == 3)
        {
            hudWeapon.hasShotgun = true;
        }
        if (index == 4)
        {
            hudWeapon.hasRaygun = true;
        }

    }
}
