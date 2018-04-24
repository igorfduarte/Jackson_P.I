using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidArea : MonoBehaviour {
    PlayerHealth health;

	// Use this for initialization
	void Start () {
        Destroy(gameObject, 8.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health = collision.GetComponent<PlayerHealth>();
            health.StartCoroutine("AcidDamage");
        }
    }
}
