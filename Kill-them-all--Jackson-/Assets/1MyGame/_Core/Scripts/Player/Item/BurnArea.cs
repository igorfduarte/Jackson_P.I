using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnArea : MonoBehaviour {
    int radius = 7;
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    
    EnemySlimeHealth slimeHealth;
    ChasePlayer chase;
    AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

	}

    
    void Update () {
        
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, 16 << LayerMask.NameToLayer("Player") | 9 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider2D nearbyObject in col)
        {
            enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
            slimeHealth = nearbyObject.GetComponent<EnemySlimeHealth>();
            playerHealth = nearbyObject.GetComponent<PlayerHealth>();
            

            if (nearbyObject.transform.tag == "Enemy" && !enemyHealth.isOnFire)
            {               
                enemyHealth.StartCoroutine("FireDamage");
                               
                print("ColorChangeToRed");

            }

            if (nearbyObject.transform.tag == "EnemyChase" && !slimeHealth.isOnFire)
            {
                
                slimeHealth.StartCoroutine("FireDamage");

                
            }
            if (nearbyObject.gameObject.tag == "Player" && !playerHealth.isOnFire)
            {
                print("player burn");
                playerHealth.StartCoroutine("FireDamage");


            }


        }
        


    }
   
}
