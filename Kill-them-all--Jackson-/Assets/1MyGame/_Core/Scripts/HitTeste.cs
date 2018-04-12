using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTeste : MonoBehaviour {

    public Transform [] SpawnPosition;
    [SerializeField] GameObject bullletPrefab;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        for (int i = 0; i < SpawnPosition.Length; i++)
        {
            GameObject tiroPistol = (GameObject)Instantiate(bullletPrefab, SpawnPosition[i].position, SpawnPosition[i].rotation);
        }
        
    }

   /* void SpawnEnemy(Transform _enemy)
    {
        Transform _spawnPos = SpawnPosition[Random.Range(0, SpawnPosition.Length)];
        Instantiate(_enemy, _spawnPos.position, _spawnPos.rotation);




    }*/
}
