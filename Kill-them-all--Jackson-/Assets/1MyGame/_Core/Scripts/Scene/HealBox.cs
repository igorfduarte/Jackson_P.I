using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBox : MonoBehaviour {

    

    //PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        //playerHealth = GetComponent<PlayerHealth>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0f);

            //playerHealth.currentHealth += 10;

            // TODO deixar apenas uma funcao collide (classe playerHealth tem collider extra)
        }
    }
}
