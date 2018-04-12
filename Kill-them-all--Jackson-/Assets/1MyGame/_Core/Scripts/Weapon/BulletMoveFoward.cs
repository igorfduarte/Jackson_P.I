using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveFoward : MonoBehaviour {
	
	[SerializeField] float speed = 10f;
    [SerializeField] float bulletDistance;
    public float damage;
    Weapon weapon;
    GameObject weaponInHand;
    GameObject player;
    // Enemy enemy;
    //  EnemyHealth enemyHealth;
    // public float damageCaused;
    // Update is called once per frame
    // public int damagePerShot = 20;
    private void OnDisable()
    {
        CancelInvoke("Desativa");
    }

    void Desativa()
    {
        gameObject.SetActive(false);
    }
    void OnEnable()
	{
        
        this.GetComponent<Rigidbody2D>().velocity = transform.up * speed;


        weaponInHand = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponInHand.GetComponent<Weapon>();
        damage = weapon.damage;


        //  enemy = FindObjectOfType<Enemy>();
        Invoke("Desativa", bulletDistance);

        

    }
	void Start () {
        /*
		Vector3 pos = transform.position;
		Vector3 velocity = new Vector3 (0, speed * Time.deltaTime, 0);
		pos += transform.rotation * velocity;
        this.GetComponent<Rigidbody2D>().velocity = velocity;
        transform.position = pos;

        */





    }

    /* void OnTriggerEnter2D(Collider2D col)
     {
         if (col.gameObject.tag == "Enemy")
         {
             Destroy(this.gameObject, 0f);

             print("bullet script");

             Debug.Log("colidiu");
         }
     }*/
          /*
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject, 0f);
            
        }


        if (other.gameObject.tag == "EnemyChase")
        {
            Destroy(this.gameObject, 0f);

        }
        if (other.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject, 0f);

        }

    }
*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            //Destroy(this.gameObject, 0);
            Desativa();
            

        }

        if (collision.gameObject.tag == "Enemy")
        {
            //Destroy(this.gameObject, 0.025f);
            Desativa();
        }


        if (collision.gameObject.tag == "EnemyChase")
        {
            //Destroy(this.gameObject, 0.025f);
            Desativa();
        }
        if (collision.gameObject.tag == "Boss")
        {
            //Destroy(this.gameObject, 0.025f);
            Desativa();
        }
    }

}
