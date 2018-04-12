using UnityEngine;
using System.Collections;

public class ZombieBossAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage = 10;
    AudioSource enemyAudio;
    Transform trans;
    Animator anim;
    GameObject player;
    [SerializeField] GameObject attackPrefab;

    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;

    bool playerInAttackRange;
    bool playerInMeeleRange;
    bool isAttacking;
    bool isDash;
    
    float timer;
    float spawnTimer;
    public AudioClip spawnUndead;
    public AudioClip deathClip;
    public AudioClip hasteClip;
    public AudioClip gonnaHaste;
    [SerializeField] GameObject attackPos;
    [SerializeField] GameObject slimePrefab;
    float speed = 25f;
    float dis;
    int generateNumber;
    [SerializeField] float minRadiusToAttack;
    [SerializeField] float minRadiusToAttackRange;
    float attackradius = 1f;

    GameObject enemy;
    ChasePlayer move;
    int cd;

    public GameObject spawnProjectilePrefab;
    



    void Start()
    {
        isDash = false;
        spawnTimer = 4;
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        trans = GetComponent<Transform>();
        enemy = this.gameObject;
        move = enemy.GetComponent<ChasePlayer>();
    }




    void GenerateNumber()
    {
        generateNumber = Random.Range(0, 5);
    }

    void Dash()
    {
        isDash = true;
        move.speed = speed;
        timer = 0;
        enemyAudio.Stop();
        enemyAudio.clip = hasteClip;
        enemyAudio.Play();
        Invoke("StopDash", 1f);
    }
    void StopDash()
    {
        isDash = false;
        move.speed = move.originalSpeed;
    }



    void Update()
    {
       
        if (timer >= timeBetweenAttacks && playerInMeeleRange)
        {
            ActiveLayer("AttackLayer");
            Attack();

        }
        else
        {
            ActiveLayer("WalkLayer");
        }
        VerifyMeeleRange();
        VerifyRangeAttack();

        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;


        if (timer >= timeBetweenAttacks && playerInAttackRange)
        {
            
            GenerateNumber();
            if (generateNumber == 1 || generateNumber == 2)
            {
                // shoot anim
                
                Shoot();
                

            }
            if (generateNumber == 3 )
            {
                //dash anim
                //dash audio
                
                print("dash");
                
                move.speed = 0;
                Invoke("Dash", 3.1f);
                
            }
            if (generateNumber == 4 && spawnTimer >= 10)

            {
                enemyAudio.Stop();
                enemyAudio.clip = spawnUndead;
                enemyAudio.Play();
                spawnTimer = 0;
                
                StartCoroutine("ShootEnemy");
            }
        
                                                
        }



        if (playerHealth.currentHealth <= 0)
        {
            enemyAudio.Stop();
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
            
            print("player morto");
            //  anim.SetTrigger ("PlayerDead");
        }

    }


    void VerifyMeeleRange()
    {
        dis = Vector3.Distance(player.transform.position, transform.position);
        Vector3 pos = transform.position;
        if (dis <= minRadiusToAttack)
        {
            
            move.speed = 0;
        }
        if (isDash)
        {
            move.speed = speed;
        }
        
        else  { move.speed = move.originalSpeed; }
        
            
    }

    void VerifyRangeAttack()   //verifica se o inimigo esta longe o suficiente
    {

        dis = Vector3.Distance(player.transform.position, transform.position);
        Vector3 pos = transform.position;
        if (dis >= minRadiusToAttackRange)
        {
            
            playerInAttackRange = true;
            //InvokeRepeating("Shoot", 1.5f,1.5f);
            //Instantiate(attackPrefab, attackPos.transform.position, trans.rotation);



        }
        else {
            playerInAttackRange = false;
            
            }

    }


    public void ActiveLayer(string layername)       // inutil 
    {
        for (int i = 0; i < anim.layerCount; i++)
        {
            anim.SetLayerWeight(i, 0);

        }
        anim.SetLayerWeight(anim.GetLayerIndex(layername), 1);
    }
   

    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {

            playerHealth.TakeDamage(attackDamage);
            anim.SetTrigger("Attacking");
        }

    }

    void Shoot()
    {
        
        timer = 0f;
        GameObject novoTiro = (GameObject)Instantiate(attackPrefab, attackPos.transform.position, trans.rotation);
        anim.SetTrigger("Attacking");
        Destroy(novoTiro.gameObject, 5f);

    }

    IEnumerator ShootEnemy()
    {
        
        for (int i = 0; i < 7; i++)
        {
            GameObject spawnEnemy = (GameObject)Instantiate(spawnProjectilePrefab, attackPos.transform.position, trans.rotation);
             
            yield return new WaitForSeconds(0.65f);
            
        }
        



    }
   

   


    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, minRadiusToAttack);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, minRadiusToAttackRange);

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {

            playerInMeeleRange = true;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            playerInMeeleRange = false;
        }
    }



   
}
