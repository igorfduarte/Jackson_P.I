using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spellMoveFoward : MonoBehaviour
{

    [SerializeField] float speed = 10f;
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
        Vector3 pos = transform.position;        

        transform.position = pos;





    }

   

}
