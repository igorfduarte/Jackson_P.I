using UnityEngine;


public class WeaponSwitch : MonoBehaviour
{
    public int selectedWeapon = 0;

    public bool hasPistol;
    public bool hasAK;
    public bool hasRayGun;
    public bool hasShotgun;
    public bool hasVector;
    public bool hasGL;

    public bool showPistol;
    public bool showAK;
    public bool showRayGun;
    public bool showShotGun;
    public bool showVector;
    public bool showGL;

    // Use this for initialization
    void Start()
    {
        hasPistol = true;
        hasAK = true;
        hasRayGun = true;
        hasShotgun = true;
        hasVector = true;
        hasGL = true;
        showGL = false;
        showVector = false;
        showPistol = true;
        showAK = false;
        showRayGun = false;
        showShotGun = false;
        SelectedWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        
        ChangeWeapon();
        
 

    }

    void SelectedWeapon() 
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
        if (selectedWeapon == 0)
        {
            showPistol = true;
            showAK = false;
            showRayGun = false;
            showShotGun = false;
            showVector = false;
            showGL = false;
        }
        if (selectedWeapon == 1)
        {
            showPistol = false ;
            showAK = true;
            showRayGun = false;
            showShotGun = false;
            showVector = false;
            showGL = false;
        }
        if (selectedWeapon == 2)
        {
            showPistol = false;
            showAK = false;
            showRayGun = true;
            showShotGun = false;
            showVector = false;
            showGL = false;
        }
        if (selectedWeapon == 3)
        {
            showPistol = false;
            showAK = false;
            showRayGun = false;
            showShotGun = true;
            showVector = false;
            showGL = false;
        }
        if (selectedWeapon == 4)
        {
            showPistol = false;
            showAK = false;
            showRayGun = false;
            showShotGun = false;
            showVector = true;
            showGL = false;
        }
        if (selectedWeapon == 5)
        {
            showPistol = false;
            showAK = false;
            showRayGun = false;
            showShotGun = false;
            showVector = false;
            showGL = true;
        }
    }



    void ChangeWeapon()
    {
        int previousSelectedWeapon = selectedWeapon;

        if (hasPistol && hasAK && hasRayGun && hasShotgun && hasVector)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 1)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 1;
                else
                    selectedWeapon--;

            }
        }
        if (hasPistol && hasAK && !hasRayGun)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 2)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 2;
                else
                    selectedWeapon--;

            }
        }
        if (hasPistol && !hasAK && !hasRayGun)
        {

            if (Input.GetAxis("Mouse ScrollWheel") > 0f)
            {
                if (selectedWeapon >= transform.childCount - 3)
                    selectedWeapon = 0;
                else
                    selectedWeapon++;

            }
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (selectedWeapon <= 0)
                    selectedWeapon = transform.childCount - 3;
                else
                    selectedWeapon--;

            }
        }













        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectedWeapon();
        }
    }











}