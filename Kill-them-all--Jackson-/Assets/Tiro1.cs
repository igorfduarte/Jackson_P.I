using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro1 : MonoBehaviour {

    [SerializeField] Transform startPos;
    [SerializeField] GameObject balaPrefab;
    public float cooldown = 0.5f;
    float timer;
    
    public Pooling pool;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Shoot", 0, cooldown);

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Shoot");
        }
    }

    private void Shoot()
    {
        GameObject possoUsar = pool.GetPooledObject();
        if (possoUsar != null)
        {
            possoUsar.transform.position = transform.position;
            possoUsar.SetActive(true);

        }
    }
}
