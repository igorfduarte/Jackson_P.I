using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeButton : MonoBehaviour {
    GameObject player;
    Experience experience;
    GameObject weaponHolder;
    Weapon weapon;
    PlayerHealth playerHealth;

    [SerializeField] bool isDamage;
    [SerializeField] bool isSpeed;
    [SerializeField] bool isLife;
    // Use this for initialization
    void Start () {
        weaponHolder = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponHolder.GetComponent<Weapon>();
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        playerHealth = player.GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Upgrade()
    {
        if (experience.experiencePoints > 0)
        {


            if (isDamage)
            {
                
                experience.damagePoints++;
                experience.experiencePoints--;
                

            }
            if (isSpeed)
            {
                experience.speedPoints++;
                experience.experiencePoints--;


            }
            if (isLife)
            {
                experience.lifePoints++;
                experience.experiencePoints--;
                experience.UpdateBonus();
                playerHealth.UpgradeLife();
                
            }
            

        }
    }
}
