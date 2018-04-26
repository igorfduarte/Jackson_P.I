using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeFollowPlayer : MonoBehaviour {
    Transform target;
    Vector2 direction;
    GameObject player;
    [SerializeField] float speed;
    [SerializeField] int currentHealth;
    float dis;
    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        target = player.GetComponent<Transform>();
        direction = target.transform.position - transform.position;
        
        direction.Normalize();

        transform.Translate(direction * speed * Time.deltaTime,Space.World);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            player.GetComponent<PlayerHealth>().TakeDamage(5);
            Destroy(gameObject);
        }
        if (col.gameObject.tag == "Bullet")
        {
            currentHealth--;
        }
        if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
