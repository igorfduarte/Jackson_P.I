using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Saber quem é o invetário
    // public Inventory inv;

    // WEAPON VARIABLES
    [SerializeField] int weaponID;

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


        if (currentAmmo <= 0)
        {
            currentAmmo = maxAmmoInHand;
        }
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
