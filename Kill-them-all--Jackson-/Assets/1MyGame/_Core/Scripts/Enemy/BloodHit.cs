using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodHit : MonoBehaviour {

    [SerializeField] Sprite bloodHit2;
    [SerializeField] Sprite bloodHit3;
    float timer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >=5 && timer <= 6)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bloodHit2;
        }
        if (timer >= 9 && timer <= 10)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bloodHit3;
            Destroy(this.gameObject, 5);
        }

    }
}
