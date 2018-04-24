using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnZombie : MonoBehaviour {

    [SerializeField]GameObject enemyPrefab;
    [SerializeField] int enemyCount;



	// Use this for initialization
	void Start () {
        StartCoroutine("SpawnEnemy");
	}
	
	// Update is called once per frame
	void Update () {

       
	}

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(1f);

        }
        Destroy(gameObject,2);
    }
}
