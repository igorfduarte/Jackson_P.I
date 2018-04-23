using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public GameObject arm;
    [SerializeField] GameObject playerHUD;
    [SerializeField] GameObject restartHUD;

    public bool hasSteelBoots;
    [SerializeField] float forceSpeed;

    public float currentEnergy = 0;
    float timer;
    public float maxHealth;
    public int shieldCooldown;
    public GameObject shield;

    public float startingHealth;
    public float currentHealth;
    public Slider healthSlider;
    public Slider energySlider;
    public Image damageImage;
    
    public AudioClip energyClip;
    public AudioClip[] hurtClip;
    public AudioClip deathClip;
    [SerializeField] AudioClip shieldHit;
    [SerializeField] AudioClip shieldEquip;



    public AudioClip ammoClip;
    public AudioClip healthClip;
    [SerializeField] GameObject fireParticle;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
    PauseMenu pause;
    Tiro tiro;
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    Color colorArm;
    SpriteRenderer spriteArm;
    Transform transArm;
    Rigidbody2D rigidArm;
    Rigidbody2D rigidPlayer;
    Collider2D playerCollider;
    SlimeExplode slime;
    GameObject slimeEnemy;
    Weapon weapon;
    GameObject player;
    
    Experience experience;
    GameObject shopObject;
    Shop shop;
    
    
    
    
    //PlayerShooting playerShooting;
    public bool isDead;
    bool damaged;
    public bool hasShield;
    public int burnTime;
    bool testeRotate;
    public bool isOnFire;
    

    public bool damageable;
    void Awake ()
    {
        pause = restartHUD.GetComponent<PauseMenu>();
        rigidPlayer = GetComponent<Rigidbody2D>();
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        experience = GetComponent<Experience>();
        player = GameObject.FindGameObjectWithTag("Weapon");
        weapon = player.GetComponentInChildren<Weapon>();
        tiro = GetComponent<Tiro>();
        playerCollider = this.gameObject.GetComponent<BoxCollider2D>();
        
        anim = GetComponent <Animator> ();
        playerAudio = GetComponent <AudioSource> ();
        playerMovement = GetComponent <PlayerMovement> ();
        //playerShooting = GetComponentInChildren <PlayerShooting> ();
        currentHealth = startingHealth;
        maxHealth = startingHealth;
        damageable = true;
        Energy();


    }

    void Energy()
    {
        energySlider.value = currentEnergy;
    }
    public void UpgradeLife()
    {
        experience = GetComponent<Experience>();
        maxHealth = startingHealth + experience.lifeBonus;
        currentHealth += experience.lifeBonus;
    }

    void Update ()
    {
        
        timer += Time.deltaTime;
        
        MaxHealth();
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * 5);



        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, 0.5f * Time.deltaTime);

        }
        damaged = false;
    }

    public void ActivateShield()
    {
        
        shield.SetActive(true);
        hasShield = true;
        
        
        playerAudio.PlayOneShot(shieldEquip, 0.3f);



    }

    public void DisableShield()
    {
        hasShield = false;
        shield.SetActive(false);
        StartCoroutine(SpawnShield());
    }

    IEnumerator SpawnShield()
    {
        yield return new WaitForSeconds(shieldCooldown);
        
        ActivateShield();
    }


    public void TakeDamage (float amount)
    {
        if (hasShield)
        {
            playerAudio.PlayOneShot(shieldHit, 0.3f);
            shield.GetComponentInChildren<ParticleSystem>().Play();
            DisableShield();
            return;
        }
        else
        {
            if (damageable == true)
            {
                damaged = true;

                currentHealth -= amount;

                // healthSlider.value = currentHealth;

                int spawnPointIndex = Random.Range(0, hurtClip.Length);

                playerAudio.clip = hurtClip[spawnPointIndex];
                playerAudio.Play();
            }
            if (currentHealth <= 0 && !isDead)
            {
                Death();
            }
            if (currentHealth > 0)
            {
                playerCollider.enabled = true;
                anim.SetBool("IsDead", false);
            }
        }
        
        
    }
    public IEnumerator FireDamage()
    {
        if (!isOnFire && !isDead)
        {
            playerMovement.StartCoroutine("ColorChangeToRed");
            isOnFire = true;
            for (int i = 0; i < burnTime; i++)
            {
                fireParticle.GetComponent<ParticleSystem>().Play();
                TakeDamage(3f);
                yield return new WaitForSeconds(1f);
            }
            isOnFire = false;

        }

    }
    IEnumerator DeathCondition()
    {
        damageable = false;
        Vector2 testeVelo = new Vector2(0, 0);
        rigidPlayer.velocity = testeVelo;
        anim.SetBool("Run", false);
        this.GetComponent<PlayerMovement>().enabled = false;
        playerHUD.SetActive(false);
        isDead = true;
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0.25f;
        damageImage.color = Color.white;
        damageImage.color = Color.Lerp(damageImage.color, Color.clear,60*Time.deltaTime);
        // screen shake
        
        //playerAudio.Stop();
        //playerAudio.clip = deathClip;
        //playerAudio.Play();
        
        transArm = arm.GetComponent<Transform>();
        transArm.parent = null;
        rigidArm = arm.GetComponent<Rigidbody2D>();
        rigidArm.isKinematic = false;
        arm.GetComponent<FaceMouse>().enabled = false;
        this.GetComponent<Tiro>().enabled = false;
        colorArm = arm.GetComponent<SpriteRenderer>().color;
        colorArm.a = 0;
        arm.GetComponent<SpriteRenderer>().color = colorArm;
        

        if (playerMovement.playerSprite.flipX == true)
        {
           
            anim.SetBool("IsDeadLeft", true);
            rigidPlayer.mass = 1;
            rigidPlayer.angularDrag = 0.1f;
            rigidPlayer.gravityScale = 1;
            Vector2 testePLayer = new Vector2(forceSpeed, forceSpeed * 2);
            rigidPlayer.AddForce(testePLayer);
            Vector2 teste = new Vector2(-forceSpeed, forceSpeed * 2);
            rigidArm.AddForce(teste);
            
        }
        else
        {
            
            anim.SetBool("IsDeadRight", true);
            rigidPlayer.mass = 1;
            rigidPlayer.angularDrag = 0.1f;
            rigidPlayer.gravityScale = 1;
            Vector2 testePLayer = new Vector2(-forceSpeed, forceSpeed * 2);
            Vector2 teste = new Vector2(forceSpeed, forceSpeed * 2);
            rigidPlayer.AddForce(testePLayer);
            rigidArm.AddForce(teste);
            
            
        }

        yield return new WaitForSeconds(1.31f);
        Vector2 testeVelo1 = new Vector2(0, 0);
        rigidPlayer.velocity = testeVelo1;
        rigidPlayer.isKinematic = true;
        rigidArm.velocity = testeVelo;
        rigidArm.isKinematic = true;
        damageImage.enabled = false;
        yield return new WaitForSeconds(0.25f);
        pause.ShowRestartUI();
        Time.timeScale = 0;

    }

    void Death ()
    {
        StartCoroutine("DeathCondition");
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Spike" && !hasSteelBoots)
        {
            if (timer >= 0.5f)
            {
                TakeDamage(15);
                timer = 0;
            }          
        }

        if (other.gameObject.tag == "BulletEnemy")        
        {
            damaged = true;
            int spawnPointIndex = Random.Range(0, hurtClip.Length);
            playerAudio.clip = hurtClip[spawnPointIndex];
            playerAudio.Play();
            currentHealth -= 10;
            healthSlider.value = currentHealth;
        }

    }

    void DamagePlayer()
    {
        slimeEnemy = GameObject.FindGameObjectWithTag("Slime");
        slime = slimeEnemy.GetComponent<SlimeExplode>();
        TakeDamage(slime.attackDamage);
        healthSlider.value = currentHealth;
    }

    void MaxHealth()
    {
        if (maxHealth < currentHealth) { currentHealth = maxHealth; }
    }

  

}
    