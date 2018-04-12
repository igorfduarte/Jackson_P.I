using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Saber quem é o invetário
    // public Inventory inv;

    // WEAPON VARIABLES

    public Transform[] startPos;

    public float damage;
    float damageMultiplier;
    float damageInicial;
    ChangeWeapon damageControl;


    public int maxAmmo;

    public int currentAmmo;

    public int maxAmmoInHand;

    public float reloadTime;

    public Pooling poolWeapon;

    public bool randomPos;

    public bool fixPos;

    public float fireRate;


    public AudioClip weaponClip;

    Experience experience;
    GameObject player;






    // AUDIO REGION


    // public AudioClip rayGunClip;
    // public AudioClip gunClip;
    // public AudioClip pistolClip;
    private void Start()
    {
        damageInicial = damage;
    }
    private void OnDisable()
    {
        damage = damageInicial;
    }

    void OnEnable()
    {

        damageControl = GetComponentInParent<ChangeWeapon>();
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        damage = damage + experience.damageBonus;


        if (currentAmmo <= 0)
        {
            currentAmmo = maxAmmoInHand;
        }

    }
    void Update()
    {

    }

    public void MultiplicarDamage()
    {


        damage = damageInicial + experience.damageBonus;
        damageControl.damageControl = damage;

    }



}
