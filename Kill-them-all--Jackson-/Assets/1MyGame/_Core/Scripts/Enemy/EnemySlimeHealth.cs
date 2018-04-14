using UnityEngine;
using System.Collections;

public class EnemySlimeHealth : MonoBehaviour
{
    [SerializeField] float experiencePoints;
    int startingHealth = 100;

    public float healthPoints;
    public int burnTime = 5;
    public int scoreValue = 10;
    public AudioClip slimeDeathClip;
    public AudioClip spawnEnergyClip;
    public AudioClip slimeHit;
    Collider2D col;
    SpriteRenderer sprite;
    SlimeExplode slimeExplode;
    BulletMoveFoward bullet;





    int spawnHealBox;
    int generateAllNumber;
    int spawnAmmoBox;
    int spawnEnergyBox;

    [SerializeField] GameObject healBox;
    [SerializeField] GameObject ammoBox;
    [SerializeField] GameObject energyBox;
    Vector3 deathPos;
    Animator anim;
    AudioSource enemyAudio;
    //ParticleSystem hitParticles;
    //CapsuleCollider capsuleCollider;
    public bool isDead;
    bool isSinking;
    public bool isOnFire;

    PlayerHealth playerHealth;
    ChasePlayer move;
    GameObject player;
    Tiro tiro;

    public GameObject slimeFloorPrefab;
    public GameObject endPos;
    Experience experience;


    void Awake()
    {
        slimeExplode = GetComponent<SlimeExplode>();
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        enemyAudio = GetComponent<AudioSource>();
        experience = player.GetComponent<Experience>();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        //capsuleCollider = GetComponent <CapsuleCollider> ();
        //bullet = GetComponent<BulletMoveFoward>();

        //col.GetComponent<Collider2D>();
        playerHealth = player.GetComponent<PlayerHealth>();
        sprite = GetComponent<SpriteRenderer>();
        move = GetComponent<ChasePlayer>();
        isDead = false;
        tiro = player.GetComponent<Tiro>();





    }
   


    void Update()
    {





        if (healthPoints <= 0 && !isDead )
        {
            Death();
            slimeExplode.GoingToExplode();
            deathPos = transform.position;
            
            experience.expAtual += experiencePoints;



            
            //TODO Fix DeathSound Click Bug
        }
    }

 
    void Death()
    {

        isDead = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        //col.enabled = false;
        //capsuleCollider.isTrigger = true;

        //anim.SetBool ("IsDead",true);

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();


    }
    public IEnumerator FireDamage()
    {
        if (!isOnFire)
        { 
            move.StartCoroutine("ColorChangeToRed");
            isOnFire = true;
            for (int i = 0; i < burnTime; i++)
            {
                TakeDamage(1.5f);
                yield return new WaitForSeconds(1);
            }
            isOnFire = false;


        }


    }
    void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.tag == "Bullet")
        {
            enemyAudio.Play();
            bullet = other.gameObject.GetComponent<BulletMoveFoward>();
            TakeDamage(bullet.damage);
            
            //anim.SetTrigger("Hit");

        }       


    }
    public void TakeDamage(float amount)
    {
        if (isDead)
            return;

        //anim.SetTrigger("Hit");
        healthPoints -= amount;

    }

   



}
