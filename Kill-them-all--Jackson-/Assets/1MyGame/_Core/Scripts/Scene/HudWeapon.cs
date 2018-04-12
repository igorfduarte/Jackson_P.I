using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudWeapon : MonoBehaviour {
    public bool hasAk = false;
    public bool hasVector = false;
    public bool hasShotgun = false;
    public bool hasRaygun = false;
    

    public GameObject ak47;
    public GameObject vector;
    public GameObject shotgun;
    public GameObject raygun;



    // Use this for initialization
    void Start () {
       

    }
	
	// Update is called once per frame
	void Update () {

        if (hasAk == true)
        {
            ak47.SetActive(true);
        }
        if (hasVector == true)
        {
            vector.SetActive(true);
        }
        if (hasShotgun == true)
        {
            shotgun.SetActive(true);
        }
        if (hasRaygun == true)
        {
            raygun.SetActive(true);
        }
        /*
        if (index[number] == 1 && weaponSpawn.hasAk == true)
        {
            print("foi");
            this.gameObject.SetActive(true);
        }
        */

    }



    
}
