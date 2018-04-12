using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAlert : MonoBehaviour {
    Experience experience;
    GameObject player;
    [SerializeField] GameObject pointAlert;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
	}
	
	// Update is called once per frame
	void Update () {
        if (experience.experiencePoints >0)
        {
            pointAlert.SetActive(true);

        }
        if (experience.experiencePoints <= 0)
        {
            pointAlert.SetActive(false);
        }
        
            
        
	}
}
