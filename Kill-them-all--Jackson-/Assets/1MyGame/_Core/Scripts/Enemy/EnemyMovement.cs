using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    SpriteRenderer enemySprite;
	GameObject player;
    [SerializeField] bool newSprite;
    EnemyHealth enemyHealth;
    [SerializeField]
    float attackRadius = 0.6f;
    [SerializeField]
    float chaseRadius = 5f;
    [SerializeField]
    public float originalSpeed;
    
    public float damageCaused;
	float dis;
    public float maxSpeed = 0f;
    Animator anim;
    public GameObject[] enemiesInRange;
    Rigidbody2D speed;
    float moveX;
    float moveY;
    bool isSlow;
    public bool isBossAttack;
    Color originalColor;
    [SerializeField] bool isSlime;

    Transform target;
    Vector2 direction;

    // Update is called once per frame
    void Start(){
        enemySprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
        speed = GetComponent<Rigidbody2D>();
        
            originalColor = enemySprite.color;
        
       
        


    }


	void Update () {

        //Debug.Log(maxSpeed);
        
           
        
        if (this.gameObject.GetComponent<SpriteRenderer>().color == Color.blue)
        {
            Invoke("ColorChangeBack", 3f);
        }



        dis = Vector3.Distance(player.transform.position, transform.position);
		Vector3 pos = transform.position;
		if (dis <= attackRadius) {
            //TODO attack animation?
            maxSpeed = 0;

		} else if(dis > chaseRadius || enemyHealth.healthPoints <=0) {
            anim.SetBool("Move", false);
            maxSpeed = 0;
		}else if(!isSlow && !isBossAttack)
        {
            anim.SetBool("Move", true);
            maxSpeed = originalSpeed;
               
        }


        /* if (enemyHealth.healthPoints <= 0)
         {
             originalSpeed = 0;
         }
         */
        // TODO apenas o clone para de andar quando morre.
        if (newSprite)
        {
            target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
            direction = target.transform.position - transform.position;
            dis = Vector3.Distance(target.transform.position, transform.position);
            direction.Normalize();
            transform.Translate(direction * maxSpeed * Time.deltaTime);
            if (target.position.x > transform.position.x)
            {
                enemySprite.flipX = false;
            }
            else
            {
                enemySprite.flipX = true;
            }
        }
        if (!newSprite)
        {
            Vector3 velocity = new Vector3(0, maxSpeed * Time.deltaTime, 0);
            anim.SetFloat("Horizontal", speed.velocity.x);
            anim.SetFloat("Vertical", speed.velocity.y);



            pos += transform.rotation * velocity;

            transform.position = pos;
        }


        
	}

    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

        // Draw chase sphere 
        Gizmos.color = new Color(0, 0, 255, .5f);
        Gizmos.DrawWireSphere(transform.position, chaseRadius);
    }

    public void SlowEffect(float slowSpeed)
    {
        isSlow = true;
        maxSpeed = slowSpeed;
        Invoke("StopSlow", 3f);
        
        
    }

    void StopSlow()
    {
        maxSpeed = originalSpeed;
        isSlow = false;
    }
    public void ColorChangeBack()
    {
        
            this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
        if (enemyHealth.isOnFire)
        {
            enemyHealth.isOnFire = false;
        }
        

        


    }
    public void ColorChangeToBlue()
    {
        CancelInvoke("ColorChangeBack");
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        
        

        print("trocou de cor?");
    }
    public IEnumerator ColorChangeToRed()
    {
        CancelInvoke("ColorChangeBack");
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(enemyHealth.burnTime);
        this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }
    

}
