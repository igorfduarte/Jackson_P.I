using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroRaycast : MonoBehaviour {

    public float distance = 5;
    public LayerMask inimigos;
    public GameObject efeito;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, distance, inimigos);
            if(hit.collider != null)
            {
                //atingiu alguma coisa
                Instantiate(efeito, hit.point, Quaternion.identity);
            }
        }
	}
}
