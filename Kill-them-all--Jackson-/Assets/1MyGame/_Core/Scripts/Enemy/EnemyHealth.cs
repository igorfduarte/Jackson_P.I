using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public float healthPoints;
    [SerializeField] int startingHealth;
    [SerializeField] bool fatEnemy;
    [SerializeField] bool normalEnemy;
    [SerializeField] int enemyPoints;
    [SerializeField] int experiencePoints;
    [SerializeField] bool isSlime;
    [SerializeField] GameObject gold1;
    [SerializeField] GameObject gold2;
    [SerializeField] GameObject gold3;   
    [SerializeField] GameObject bloodHit;
    [SerializeField] GameObject bloodDeath;
    [SerializeField] GameObject hitParticles;
    [SerializeField] GameObject fireParticle;

    public Transform bloodPos;   
    public CameraFollow cameraShake;
    public GameObject endPos;
    public bool isDead;
    public bool isOnFire;
    public int burnTime;

    GameObject scoreObject;
    GameObject goldToSpawn;
    GameObject player;
    Vector3 deathPos;
    Experience experience;
    BulletMoveFoward bullet;
    Score scorePoints;
    Gold gold;
    PlayerHealth playerHealth;
    EnemyMovement move;   
    Tiro tiro;
    Animator anim;
    AudioSource enemyAudio;
    Collider2D col;
    SpriteRenderer sprite;


 
    bool isSinking;    
    public int goldMax;
    float timer;
    int spawnHealBox;
    int generateAllNumber;
    int spawnAmmoBox;
    int spawnEnergyBox;
    int goldAmount;



    void Awake ()
    {
        
        goldAmount = Random.Range(0, goldMax);
        GenerateGold();
        scoreObject = GameObject.FindGameObjectWithTag("Score");
        scorePoints = scoreObject.GetComponent<Score>();
        healthPoints = startingHealth;
        
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        //hitParticles = GetComponentInChildren <ParticleSystem> ();
        //capsuleCollider = GetComponent <CapsuleCollider> ();
        //bullet = GetComponent<BulletMoveFoward>();
        
        //col.GetComponent<Collider2D>();
        playerHealth = player.GetComponent<PlayerHealth>();
        sprite = GetComponent<SpriteRenderer>();
        move = GetComponent<EnemyMovement>();
        tiro = player.GetComponent<Tiro>();

        cameraShake = Camera.main.transform.parent.GetComponent<CameraFollow>();

    }
   

    void Update ()
    {
        timer += Time.deltaTime;    

       if (healthPoints <= 0 && !isDead )
        {
            
        //playerHealth.currentEnergy += 5;
        Death();

        Destroy(this.gameObject, 1.25f);
        deathPos = transform.position;
                
                           
        //TODO Fix DeathSound Click Bug
        }
    }

    

    public void TakeDamage (float amount)
    {
        if(isDead)
           return;

         enemyAudio.Play ();
        SpawnBlood();
        healthPoints -= amount;
        cameraShake.ShakeCamera(0.03f, 0.05f);
        FlashDamage();
        anim.SetTrigger("Hit");
        GameObject novoParticle = (GameObject)Instantiate(hitParticles, transform.position, transform.rotation);
        Destroy(novoParticle, 1f);
        //hitParticles.transform.position = hitPoint;
        // hitParticles.Play();
    }
    
    IEnumerator SpawnDeathBlood()
    {

        yield return new WaitForSeconds(0.85f);
        Instantiate(bloodDeath, transform.position, transform.rotation);

    }
    void Death ()
    {
        experience.expAtual += experiencePoints;
        scorePoints.score += enemyPoints;
        isDead = true;
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        StartCoroutine("SpawnDeathBlood");

        //col.enabled = false;
        //capsuleCollider.isTrigger = true;

        //anim.SetBool ("IsDead",true);

        //enemyAudio.clip = deathClip;
        //enemyAudio.Play ();

        if (goldAmount >0)
        {
            SpawnGold();            
        }            
    }

    void FlashDamage()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
        Invoke("StopFlashDamage", 0.05f);
    }
    void StopFlashDamage()
    {
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            if (timer >= 0.5f)
            {
                TakeDamage(3f);
                timer = 0;
            }           
        }
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Bullet")
        {
            bullet = other.gameObject.GetComponent<BulletMoveFoward>();
            TakeDamage(bullet.damage);
        }

    }

    private void SpawnBlood()
    {
        if (timer >= 0.5f && (healthPoints/startingHealth >= 0.2f))
        {
            Instantiate(bloodHit, transform.position, transform.rotation);
            timer = 0;
        }       
    }

    void GenerateGold()
    {              
        if (goldAmount >0 && goldAmount < 12)
        {
            goldToSpawn = gold1;
        }
        if (goldAmount >=12 && goldAmount<20)
        {
            goldToSpawn = gold2;
        }
        if (goldAmount > 20 && goldAmount <= 30)
        {
            goldToSpawn = gold3;
        }      
    }

    void SpawnGold()
    {
        if (goldToSpawn != null)
        {
            GameObject newGold = (GameObject)Instantiate(goldToSpawn, transform.position, Quaternion.identity);
            gold = newGold.GetComponent<Gold>();
            gold.goldAmount = +goldAmount;
        }
        /*
        if (goldToSpawn != null)
        {
            GameObject newGold = (GameObject)Instantiate(goldToSpawn, transform.position, transform.rotation);
            gold = newGold.GetComponent<Gold>();
            gold.goldAmount = goldAmount;
        }
        */                
    }

public IEnumerator FireDamage()
    {
        if (!isOnFire)
        {
            move.StartCoroutine("ColorChangeToRed");
            isOnFire = true;
            for (int i = 0; i < burnTime; i++)
            {
                fireParticle.GetComponent<ParticleSystem>().Play();
                TakeDamage(2f);
                yield return new WaitForSeconds(1);
            }
            isOnFire = false;
            

        }
        
        
    }

   

}
