using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    public float timeBetweenAttacks;
    public int attackDamage = 10;

 
    AudioSource playerAudio2;
    Animator anim;
    GameObject player;
    public AudioClip deathClip;
    

    PlayerHealth playerHealth;
    
    bool playerInRange;
   
    float timer;



   






    void Awake ()
    {
        playerAudio2 = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerHealth = player.GetComponent <PlayerHealth> ();
        
        
        anim = GetComponent <Animator> ();
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject == player)
        {
           
            playerInRange = true;
        }
    }


    void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update ()
    {
        
        
        
        timer += Time.deltaTime;

        if(timer >= timeBetweenAttacks && playerInRange )
        {
            Attack ();
            
        }
        

        if (playerHealth.currentHealth <= 0)
        {
            playerAudio2.Stop();
            
            anim.SetTrigger("IsDead");
            this.GetComponent<EnemyMovement>().enabled = false;
            this.GetComponent<EnemyAttack>().enabled = false;
            //Destroy(player, 2f);
            print("player morto");
          //  anim.SetTrigger ("PlayerDead");
        }
        
    }


    void Attack ()
    {
        timer = 0f;

        if(playerHealth.currentHealth > 0)
        {
            
            playerHealth.TakeDamage (attackDamage);
            anim.SetTrigger("Attack");
        }
    }

    
        
    }
    
    
