using UnityEngine;
using System.Collections;

public class FatEnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage = 10;

    


    //AudioSource playerAudio2;
    Animator anim;
    GameObject player;
    //public AudioClip deathClip;
    PlayerMovement playerMove;

    PlayerHealth playerHealth;
    EnemyHealth enemyHealth;
    bool playerInRange;

    float timer;



    float slowSpeed = 3.5f;






    void Awake()
    {
        //playerAudio2 = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerMove = player.GetComponent<PlayerMovement>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject == player)
        {

            playerInRange = true;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {



        timer += Time.deltaTime;

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();

        }


        if (playerHealth.currentHealth <= 0)
        {
            //playerAudio2.Stop();
            //playerAudio2.clip = deathClip;
           // playerAudio2.Play();
            

            
           
            
        }

    }


    void Attack()
    {
        timer = 0f;

        if (playerHealth.currentHealth > 0)
        {
            playerMove.SlowEffect(slowSpeed);
            playerHealth.TakeDamage(attackDamage);
            anim.SetTrigger("Attack");
        }
    }



}


