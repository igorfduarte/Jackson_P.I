using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour {
    HudWeapon hudWeapon;
    GameObject weapon;

    [SerializeField] GameObject ak;
    [SerializeField] GameObject vector;
    [SerializeField] GameObject shotgun;
    [SerializeField] GameObject raygun;
    [SerializeField] GameObject pistol;

    public bool hasAk = false;
    public bool hasVector = false;
    public bool hasShotgun = false;
    public bool hasRaygun = false;
    public bool hasPistol = true;
    public float damageControl;


    // Use this for initialization
    void Start () {
        weapon = GameObject.FindGameObjectWithTag("HUDWeapon");
        hudWeapon = weapon.GetComponent<HudWeapon>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            pistol.SetActive(true);
            ak.SetActive(false);
            vector.SetActive(false);
            shotgun.SetActive(false);
            raygun.SetActive(false);

            hasPistol = true;
            hasAk = false;
            hasVector = false;
            hasShotgun = false;
            hasRaygun = false;


            

        }
        if (Input.GetKey(KeyCode.Alpha2) && hudWeapon.hasAk == true)
        {
            pistol.SetActive(false);
            ak.SetActive(true);
            vector.SetActive(false);
            shotgun.SetActive(false);
            raygun.SetActive(false);

            hasPistol = false;
            hasAk = true;
            hasVector = false;
            hasShotgun = false;
            hasRaygun = false;
        }
        if (Input.GetKey(KeyCode.Alpha3) && hudWeapon.hasVector == true)
        {
            pistol.SetActive(false);
            ak.SetActive(false);
            vector.SetActive(true);
            shotgun.SetActive(false);
            raygun.SetActive(false);

            hasPistol = false;
            hasAk = false;
            hasVector = true;
            hasShotgun = false;
            hasRaygun = false;
        }
        if (Input.GetKey(KeyCode.Alpha4) && hudWeapon.hasShotgun == true)
        {
            pistol.SetActive(false);
            ak.SetActive(false);
            vector.SetActive(false);
            shotgun.SetActive(true);
            raygun.SetActive(false);

            hasPistol = false;
            hasAk = false;
            hasVector = false;
            hasShotgun = true;
            hasRaygun = false;

        }
        if (Input.GetKey(KeyCode.Alpha5) && hudWeapon.hasRaygun == true)
        {
            pistol.SetActive(false);
            ak.SetActive(false);
            vector.SetActive(false);
            shotgun.SetActive(false);
            raygun.SetActive(true);

            hasPistol = false;
            hasAk = false;
            hasVector = false;
            hasShotgun = false;
            hasRaygun = true;

        }

    }
}
