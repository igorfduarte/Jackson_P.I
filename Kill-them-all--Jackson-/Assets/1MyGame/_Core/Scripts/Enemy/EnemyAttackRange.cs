using UnityEngine;
using System.Collections;

public class EnemyAttackRange : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage = 10;
    AudioSource enemyAudio;
    Transform trans;
    Animator anim;
    GameObject player;
    [SerializeField] GameObject attackPrefab;
    [SerializeField] Transform[] spawnPos;
    [SerializeField] float intervaloDeTiro;
    [SerializeField] float spawnProjectileCountTime;

    PlayerHealth playerHealth;

    
    bool playerInAttackRange;
    
    float timer;
    public AudioClip shootClip;
    public AudioClip deathClip;
    [SerializeField]GameObject attackPos;

     float dis;
    [SerializeField] float attackRadius;
    float spawnTimer = 0;






    void Awake ()
    {
        enemyAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        
        anim = GetComponent <Animator> ();
        trans = GetComponent<Transform>();
        
    }

    void Start()
    {
        timer = 2;
    }


   


    


    void Update ()
    {
        

        Debug.Log(spawnTimer);
        
        AttackRange();
        
        timer += Time.deltaTime;

        
        if (timer >= timeBetweenAttacks && playerInAttackRange)
        {

            InvokeRepeating("Shoot2", 0, intervaloDeTiro);
            spawnTimer = 0;
            timer = 0;
            Invoke("CancelShoot2", intervaloDeTiro*spawnProjectileCountTime);
        }

        if (playerHealth.currentHealth <= 0)
        {
            enemyAudio.Stop();
            enemyAudio.clip = deathClip;
            enemyAudio.Play();
            Destroy(player, 1f);
            print("player morto");
          //  anim.SetTrigger ("PlayerDead");
        }

 

    }

    void CancelShoot2()
    {
        CancelInvoke("Shoot2");

    }
    

    void AttackRange()
    {

        dis = Vector3.Distance(player.transform.position, transform.position);
        Vector3 pos = transform.position;
        if (dis <= attackRadius)
        {
            playerInAttackRange = true;
            //InvokeRepeating("Shoot", 1.5f,1.5f);
            //Instantiate(attackPrefab, attackPos.transform.position, trans.rotation);



        }
        else { playerInAttackRange = false; }
        
    }
    void Shoot()
    {

        timer = 0f;
        GameObject novoTiro = (GameObject)Instantiate(attackPrefab, attackPos.transform.position, trans.rotation);
        
        Destroy(novoTiro.gameObject, 8f);

    }

    void Shoot2()
    {


        enemyAudio.clip = shootClip;
        enemyAudio.Play();
        anim.SetTrigger("Attack");
        for (int y = 0; y < spawnPos.Length; y++)
            {
            
            GameObject tiroPistol = (GameObject)Instantiate(attackPrefab, spawnPos[y].position, spawnPos[y].rotation);
                Destroy(tiroPistol.gameObject, 8f);


        }



    }
    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, attackRadius);

    }

}
