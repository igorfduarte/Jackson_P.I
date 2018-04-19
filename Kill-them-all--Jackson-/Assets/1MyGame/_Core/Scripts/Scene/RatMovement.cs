using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RatMovement : MonoBehaviour {
    [SerializeField] int speed;
    [SerializeField] Transform startPos;
    [SerializeField] Transform endPos;
    int randomNumber;


    // Use this for initialization
    void Start () {



	}
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.up* speed * Time.deltaTime;

        if (transform.position.x <= endPos.position.x)
        {
            transform.position = startPos.position;
        }

    }
}
