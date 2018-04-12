using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnManager : MonoBehaviour {

   
    [SerializeField] int index;
    HudWeapon hudWeapon;
    GameObject weapon;


	// Use this for initialization
	void Start () {
        weapon = GameObject.FindGameObjectWithTag("HUDWeapon");
        hudWeapon = weapon.GetComponent<HudWeapon>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
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
