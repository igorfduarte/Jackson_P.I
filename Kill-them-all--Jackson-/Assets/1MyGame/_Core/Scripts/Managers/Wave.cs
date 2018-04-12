using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {
    
     public Transform enemy;
     public Transform fatEnemy;
     public Transform slimeEnemy;
    public Transform rangeEnemy;


    public int count = 5;
    public int fatEnemyCount = 0;
    public int slimeEnemyCount = 0;
    public int rangeCount = 0;
    public float rate;   // spawn rate
    int countMultiplier;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
