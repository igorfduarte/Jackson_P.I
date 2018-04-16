using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoveFoward : MonoBehaviour {
	
	[SerializeField] float speed = 10f;
    [SerializeField] float bulletDistance;
    [SerializeField] GameObject wallHitPrefab;
    [SerializeField] bool isRayGun;
    [SerializeField] float radius;
    public float damage;
    Weapon weapon;
    EnemyHealth enemyHealth;
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
        player = GameObject.FindGameObjectWithTag("Player");      
        this.GetComponent<Rigidbody2D>().velocity = transform.up * speed;
        weaponInHand = GameObject.FindGameObjectWithTag("Weapon");
        weapon = weaponInHand.GetComponent<Weapon>();
        damage = weapon.damage;


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

    private void Update()
    {
        if (isRayGun)
        {
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, 13 << LayerMask.NameToLayer("Wall"));

            foreach (Collider2D nearbyObject in col)
            {
                if (nearbyObject.tag == "Wall")
                {
                    StartCoroutine("SetTrigger");
                }
               
               
               
            }
        }
    }

    IEnumerator SetTrigger()
    {
        this.GetComponent<Collider2D>().isTrigger = false;
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Collider2D>().isTrigger = true;

    }

  
    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, radius);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Desativa();

        }
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
       

        if (collision.gameObject.tag == "Wall" && !isRayGun)
        {
            if ((transform.position.y - player.transform.position.y)>-6 && (transform.position.y - player.transform.position.y) < 0)
            {
                Vector3 newPos = new Vector3(0f, -0.5f, 0);
                Instantiate(wallHitPrefab, (transform.position + newPos), transform.rotation);
                //Destroy(this.gameObject, 0);
                Desativa();
            }
            if ((transform.position.y - player.transform.position.y) < -6 )
            {
                Vector3 newPos = new Vector3(0f, -1f, 0);
                Instantiate(wallHitPrefab, (transform.position + newPos), transform.rotation);
                //Destroy(this.gameObject, 0);
                Desativa();
            }

            if ((transform.position.y - player.transform.position.y) > 0 && (transform.position.y - player.transform.position.y)<5)
            {
                Vector3 newPos = new Vector3(0f, 1f, 0);
                Instantiate(wallHitPrefab, (transform.position + newPos), transform.rotation);
                //Destroy(this.gameObject, 0);
                Desativa();
            }
            if ((transform.position.y - player.transform.position.y) > 5)
            {
                Vector3 newPos = new Vector3(0f, 2.5f, 0);
                Instantiate(wallHitPrefab, (transform.position + newPos), transform.rotation);
                //Destroy(this.gameObject, 0);
                Desativa();
            }


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
