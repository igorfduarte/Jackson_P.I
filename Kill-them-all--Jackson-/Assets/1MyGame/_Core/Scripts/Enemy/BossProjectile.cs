using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectile : MonoBehaviour {

    Transform target;
    public float speed = 10f;

    
    Vector2 direction;
    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        direction = target.transform.position - transform.position;
        direction.Normalize();
        Move();
        

        

        // transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // anim.SetFloat("Vertical", rigid.velocity.y);
        // anim.SetFloat("Horizontal", rigid.velocity.x);
    }
    void Move()
    {
       // transform.Rotate(new Vector3(0, 0, 10), Space.Self);
        transform.Translate(direction * speed * Time.deltaTime);
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter2D(Collider2D other)
    {


        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject, 0f);

        }
    }
}
