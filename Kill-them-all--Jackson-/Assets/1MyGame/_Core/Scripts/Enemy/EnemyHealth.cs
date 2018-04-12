using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] bool fatEnemy;
    [SerializeField] bool normalEnemy;

    [SerializeField]
     int startingHealth;
    [SerializeField] int enemyPoints;
    [SerializeField] int experiencePoints;
    [SerializeField] bool isSlime;
    int goldAmount;
    public float healthPoints;

    public int scoreValue = 10;
    public AudioClip slimeDeathClip;
    public Transform bloodPos;
   
    public AudioClip slimeHit;
    Collider2D col;
    SpriteRenderer sprite;
    SlimeExplode slimeExplode;





    int goldMax;
    float timer;
    int spawnHealBox;
    int generateAllNumber;
    int spawnAmmoBox;
    int spawnEnergyBox;
    [SerializeField] GameObject gold1;
    [SerializeField] GameObject gold2;
    [SerializeField] GameObject gold3;
    GameObject goldToSpawn;
    [SerializeField] GameObject bloodHit;
    [SerializeField] GameObject bloodDeath;
    [SerializeField] GameObject healBox;
    [SerializeField] GameObject ammoBox;
    [SerializeField] GameObject energyBox;
    public Vector3 deathPos;
    Animator anim;
    AudioSource enemyAudio;
    [SerializeField]GameObject hitParticles;
    //CapsuleCollider capsuleCollider;
    public bool isDead;
    bool isSinking;
    public CameraFollow cameraShake;
    PlayerHealth playerHealth;
    EnemyMovement move;
    GameObject player;
    Tiro tiro;

    public GameObject slimeFloorPrefab;
    public GameObject endPos;
    BulletMoveFoward bullet;

    Score scorePoints;
    GameObject scoreObject;

    Experience experience;
    Gold gold;
    



    void Awake ()
    {
        if (fatEnemy)
        {
            goldMax = 30;
        }
        if (normalEnemy)
        {
            goldMax = 20;
        }
        goldAmount = Random.Range(0, goldMax);
        GenerateGold();
        scoreObject = GameObject.FindGameObjectWithTag("Score");
        scorePoints = scoreObject.GetComponent<Score>();
        healthPoints = startingHealth;
        slimeExplode = GetComponent<SlimeExplode>();
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
    void GenerateAllNumber()
    {
        generateAllNumber = Random.Range(0, 3);
    }
    void GenerateHealBoxNumber()
    {
        spawnHealBox = Random.Range(0, 6);
    }
    void GenerateAmmoBoxNumber()
    {
        spawnAmmoBox = Random.Range(0, 8);
    }
    void GenerateEnergyBoxNumber()
    {
        spawnEnergyBox = Random.Range(0, 7);
    }


    void Update ()
    {
        timer += Time.deltaTime;

       


            if (healthPoints <= 0 && !isDead )
        {
            if (isSlime)
            {
                slimeExplode.GoingToExplode();
                Death();

                Destroy(this.gameObject, 1.25f);
                deathPos = transform.position;
                GenerateAllNumber();
                //SpawnLoot();
            }
            else
            {
                //playerHealth.currentEnergy += 5;
                Death();

                Destroy(this.gameObject, 1.25f);
                deathPos = transform.position;
                GenerateAllNumber();
                //SpawnLoot();
            }
            //TODO Fix DeathSound Click Bug
        }
    }

    private void SpawnLoot()
    {
        if (generateAllNumber == 0)
        {

            GenerateHealBoxNumber();
            if (spawnHealBox == 2)
            {

                Instantiate(healBox, deathPos, Quaternion.identity);
            }
        }
        if (generateAllNumber == 1)
        {
            GenerateAmmoBoxNumber();

            if (spawnAmmoBox == 2)
            {

                Instantiate(ammoBox, deathPos, Quaternion.identity);
            }
        }
        if (generateAllNumber == 2)
        {

            GenerateEnergyBoxNumber();
            if (spawnEnergyBox == 3)
            {


                Instantiate(energyBox, deathPos, Quaternion.identity);
            }

        }
    }

    public void TakeDamage (float amount)
    {
        if(isDead)
           return;

        // enemyAudio.Play ();
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
        if (other.gameObject.tag == "Ultimate")
        {
            print("colidiu com enemy");
            enemyAudio.Play();

            healthPoints -= 50f;

        }

        if (other.gameObject.tag == "Slow")
        {
            sprite.color = Color.blue;
            move.SlowEffect(0.5f);
            
            print("ficou Slow");
            

        }


        if (other.gameObject.tag == "Bullet")
        {
            bullet = other.gameObject.GetComponent<BulletMoveFoward>();
            TakeDamage(bullet.damage);

        }

        if (other.gameObject.tag == "Ultimate")
        {
            enemyAudio.Play();

            healthPoints -= 50f;

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

}
