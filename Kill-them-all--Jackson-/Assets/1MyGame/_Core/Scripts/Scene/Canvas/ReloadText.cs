using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReloadText : MonoBehaviour {

    GameObject weaponObject;
    Weapon weapon;
    [SerializeField] GameObject textReload;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponObject.GetComponent<Weapon>();
        if (weapon.currentAmmo <=0 && weapon.maxAmmo >=0)
        {
            textReload.SetActive(true);
        }
        else
        {
            textReload.SetActive(false);
        }

	}
    
}
