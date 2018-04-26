using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrop : MonoBehaviour {

    [SerializeField] GameObject gold1;
    [SerializeField] GameObject gold2;
    [SerializeField] GameObject gold3;
    Rigidbody2D rigidGold;
    [SerializeField] Transform[] startPos;
    int force;
    bool hasSpawned;
    public bool finishSpawn;
    Vector2 forca;
    int goldAmount;
    GameObject goldtoSpawn;
    

    EnemyHealth health;
	// Use this for initialization
	void Start () {
        health = GetComponent<EnemyHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        if (health.spitterDead && !hasSpawned)
        {
            StartCoroutine("SpawnGold");
            hasSpawned = true;

        }
	}

    IEnumerator SpawnGold()
    {
        for (int i = 0; i < 10; i++)
        {
            goldAmount = Random.Range(0, health.goldMax);
            if (goldAmount < 15)
            {
                goldtoSpawn = gold1;
            }
            if (goldAmount >=15 && goldAmount < 30)
            {
                goldtoSpawn = gold2;
            }
            if (goldAmount >=30)
            {
                goldtoSpawn = gold3;
            }

            int spawnPointIndex = Random.Range(0, startPos.Length);
            GameObject novoGold = (GameObject)Instantiate(goldtoSpawn, startPos[spawnPointIndex].position, startPos[spawnPointIndex].rotation);
            rigidGold = novoGold.GetComponent<Rigidbody2D>();
            rigidGold.isKinematic = false;

            novoGold.GetComponent<Gold>().goldAmount = goldAmount;
            int numberX = Random.Range(-25, -300);
            int numberY = Random.Range(25, 300);

            if (spawnPointIndex == 0)
            {
                forca = new Vector2 (-numberX, numberY);
            }
            else
            {              
                forca = new Vector2(numberX, numberY);
            }      
            rigidGold.AddForce(forca);
            Destroy(novoGold.gameObject, 60f);
            yield return new WaitForSeconds(0.5f);
            Vector2 testeVelo1 = new Vector2(0, 0);
            rigidGold.velocity = testeVelo1;
            rigidGold.isKinematic = true;

        }
        finishSpawn = true;
    }
}
