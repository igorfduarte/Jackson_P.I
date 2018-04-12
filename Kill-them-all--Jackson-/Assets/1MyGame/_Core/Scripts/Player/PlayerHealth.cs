using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour
{
    public bool hasSteelBoots;

    public float currentEnergy = 0;
    float timer;
    public float maxHealth;
    public int shieldCooldown;
    public GameObject shield;

    public float startingHealth = 100;
    public float currentHealth;
    public Slider healthSlider;
    public Slider energySlider;
    public Image damageImage;
    
    public AudioClip energyClip;
    public AudioClip[] hurtClip;
    public AudioClip deathClip;


    public AudioClip ammoClip;
    public AudioClip healthClip;
    public float flashSpeed = 5f;
    public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

    Tiro tiro;
    Animator anim;
    AudioSource playerAudio;
    PlayerMovement playerMovement;

    Collider2D playerCollider;
    SlimeExplode slime;
    GameObject slimeEnemy;
    Weapon weapon;
    GameObject player;
    Experience experience;
    GameObject shopObject;
    Shop shop;
    
    
    
    
    //PlayerShooting playerShooting;
    bool isDead;
    bool damaged;
    public bool hasShield;
    

    public bool damageable;
    void Awake ()
    {
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
        maxHealth = maxHealth + experience.lifeBonus;
        currentHealth += experience.lifeBonus;
    }

    void Update ()
    {
        

        timer += Time.deltaTime;
        MaxEnergy();
        MaxHealth();
        healthSlider.value = Mathf.Lerp(healthSlider.value, currentHealth, Time.deltaTime * 5);



        if (damaged)
        {
            damageImage.color = flashColour;
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);


        }
        damaged = false;
    }

    public void ActivateShield()
    {
        
            shield.SetActive(true);
        
    }

    IEnumerator SpawnShield()
    {
        yield return new WaitForSeconds(shieldCooldown);
        hasShield = true;
        ActivateShield();
    }


    public void TakeDamage (int amount)
    {
        if (hasShield)
        {
            shield.SetActive(false);
            StartCoroutine(SpawnShield());
        }
        if (damageable == true && !hasShield) {
            damaged = true;

            currentHealth -= amount;

           // healthSlider.value = currentHealth;
            
            int spawnPointIndex = Random.Range(0, hurtClip.Length);

            playerAudio.clip = hurtClip[spawnPointIndex];
            playerAudio.Play();
        }
        if (currentHealth <= 0 && !isDead)
        {
            Death ();
        }
        if (currentHealth > 0)
        {
            playerCollider.enabled = true;
            anim.SetBool("IsDead", false);
        }
        
    }


    void Death ()
    {
        playerCollider.enabled = false;
        playerAudio.Stop();
        playerAudio.clip = deathClip;
        playerAudio.Play();
        isDead = true;

        //playerShooting.DisableEffects ();
        
        anim.SetBool("IsDead", true);




        playerMovement.enabled = false;
        //playerShooting.enabled = false;
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
            if (other.gameObject.tag == "HealBox")
        {

            playerAudio.clip = healthClip;
            playerAudio.Play();
            currentHealth += 25;
            healthSlider.value = currentHealth;

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

        if (other.gameObject.tag == "AmmoBox")
        {
            playerAudio.clip = ammoClip;
            playerAudio.Play();
            weapon.maxAmmo += 100;
            
            


            //TODO update Canvas de ammo de acordo com a arma
            
        }

        if (other.gameObject.tag == "EnergyBox")
        {

            playerAudio.clip = energyClip;
            playerAudio.Play();
            currentEnergy += 25;
            energySlider.value = currentEnergy;

        }

       

    }

    void DamagePlayer()
    {
        slimeEnemy = GameObject.FindGameObjectWithTag("Slime");
        slime = slimeEnemy.GetComponent<SlimeExplode>();
        TakeDamage(slime.attackDamage);
        healthSlider.value = currentHealth;
    }



    void MaxEnergy()
    {
        if (currentEnergy > 100) { currentEnergy = 100; }
    }
    void MaxHealth()
    {
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
    }

  

}
    