using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnArea : MonoBehaviour {
    int radius = 7;
    EnemyHealth enemyHealth;
    
    EnemySlimeHealth slimeHealth;
    ChasePlayer chase;
    AudioSource audioSource;


	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

	}

    
    void Update () {
        
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, 9 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider2D nearbyObject in col)
        {
            enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
            slimeHealth = nearbyObject.GetComponent<EnemySlimeHealth>();
            

            if (nearbyObject.transform.tag == "Enemy" && !enemyHealth.isOnFire)
            {               
                enemyHealth.StartCoroutine("FireDamage");
                               
                print("ColorChangeToRed");

            }

            if (nearbyObject.transform.tag == "EnemyChase" && !slimeHealth.isOnFire)
            {
                
                slimeHealth.StartCoroutine("FireDamage");

                print("ColorChangeToBlue");
            }

        }
        

    }
   
}
