using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileZombie : MonoBehaviour {
    public GameObject spawnEnemyPrefab;
    Transform target;
    public float speed = 10;
    Vector2 direction;

    // Use this for initialization
    void Start () {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        Move();
        direction = target.transform.position - transform.position;
        direction.Normalize();
        Invoke("SpawnEnemy", 1.5f);
	}

    void SpawnEnemy()
    {
        GameObject spawnEnemy = (GameObject)Instantiate(spawnEnemyPrefab, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    void Move()
    {
        // transform.Rotate(new Vector3(0, 0, 10), Space.Self);
        transform.Translate(direction * speed * Time.deltaTime);
        
    }
}
