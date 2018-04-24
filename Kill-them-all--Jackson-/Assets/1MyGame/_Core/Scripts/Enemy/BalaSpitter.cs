using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BalaSpitter : MonoBehaviour {

    [SerializeField] GameObject acidArea;
    GameObject player;
    PlayerHealth health;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            health.TakeDamage(5);
            Instantiate(acidArea, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Wall")
        {
            Instantiate(acidArea, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    
}
