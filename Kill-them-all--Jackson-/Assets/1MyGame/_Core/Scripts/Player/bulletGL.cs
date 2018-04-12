using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletGL : MonoBehaviour {
    [SerializeField] float speed = 100;
    Rigidbody2D rigid;
    Animation anim;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody2D>();
        rigid.AddForce(transform.up * speed);
        
        anim = GetComponent<Animation>();
        Invoke("Explode", 1.255f);
    }

    void Explode()
    {
        anim.Play();
        Destroy(gameObject, 1.3f);
    }
	// Update is called once per frame
	void Update () {
        
    }
}
