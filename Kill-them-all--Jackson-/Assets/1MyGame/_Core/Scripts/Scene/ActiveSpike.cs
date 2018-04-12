using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpike : MonoBehaviour {
    Collider2D col;

    
    float timer;

	// Use this for initialization
	void Start () {




        col = GetComponent<Collider2D>();
        StartCoroutine("Spike");

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        
	}
    IEnumerator Spike()
    {
        while (true)
        {
            col.enabled = false;
            yield return new WaitForSeconds(3f);
            col.enabled = true;
            yield return new WaitForSeconds(3f);
        }
    }

    

}
