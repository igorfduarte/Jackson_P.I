using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

   
    // Enemy enemy;
    //  EnemyHealth enemyHealth;
    // public float damageCaused;
    // Update is called once per frame
    // public int damagePerShot = 20;
    void Start()
    {
        //  enemy = FindObjectOfType<Enemy>();

    }
    void Update()
    {
  







    }

    /* void OnTriggerEnter2D(Collider2D col)
     {
         if (col.gameObject.tag == "Enemy")
         {
             Destroy(this.gameObject, 0f);

             print("bullet script");

             Debug.Log("colidiu");
         }
     }*/

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0f);

        }

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0f);

        }

    }

}
