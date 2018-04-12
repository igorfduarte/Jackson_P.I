using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveWeaponHud : MonoBehaviour {
    HudWeapon weapon;
    int[] index;
    [SerializeField] int number;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (index[number] == 1 && weapon.hasAk == true)
        {
            
            this.gameObject.SetActive(true);
        }
    }
}
