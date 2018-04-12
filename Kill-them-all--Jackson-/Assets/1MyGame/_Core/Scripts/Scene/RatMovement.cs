using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatMovement : MonoBehaviour {
    [SerializeField] int speed;
    int randomNumber;

	// Use this for initialization
	void Start () {
        
        

	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up* speed * Time.deltaTime;

    }
}
