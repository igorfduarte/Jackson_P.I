using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] GameObject wavePosition;
    [SerializeField] GameObject shopPosition;
    [SerializeField] float velocidade = 6f;
    [SerializeField] float maxStamina = 100;
    [SerializeField] float timeToFullStamina;
    [SerializeField] float velocidadeDash;
    [SerializeField] GameObject teleportToWave;
    [SerializeField] GameObject teleportToShop;

    Rigidbody2D rigid;
    Animator anim;
    AudioSource playerAudio;
    Teleport teleport;
    PlayerHealth playerHealth;
    Experience experience;
    FaceMouse facemouse;
    SpriteRenderer playerSprite;
    public AudioClip dashClip;
    public AudioClip portalClip;
    public GameObject arm;
    public GameObject poisonEffect;
    public GameObject steelBootsEffect;
    public Slider staminaSlider;
    public Image damageImage;
    Color originalColor;

    public bool isSlow;

    bool isInShopTeleport;
    bool isInWaveTeleport;
    bool canDash = true;
    float currentStamina;
    float velocidadeOriginal;
    float velocidadeAtual;
    float tempoDash = 0.2f;
    bool estaDandoDash;
	float moveX;
	float moveY;

    void Start () {
        playerSprite = GetComponent<SpriteRenderer>();
        facemouse = arm.GetComponent<FaceMouse>();
        experience = GetComponent<Experience>();
        currentStamina = maxStamina;
        velocidadeOriginal = velocidade;
		rigid = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
        playerHealth = GetComponent<PlayerHealth>();
        Velocidade();
        originalColor = this.gameObject.GetComponent<SpriteRenderer>().color;




    }
    void StopDash()
    {
        estaDandoDash = false;
        Velocidade();
        //colli.enabled = true;
        playerHealth.damageable = true;
        Invoke("FillStamina", timeToFullStamina);
        this.gameObject.layer = 16;

    }
    void FillStamina()
    {
        currentStamina = 100;
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && !estaDandoDash && canDash && currentStamina == 100)
        {
            playerHealth.damageable = false;
            //colli.enabled = false;
            anim.SetTrigger("EstaDandoDash");
            estaDandoDash = true;
            velocidadeAtual = velocidadeDash;
            Invoke("StopDash", tempoDash);
            playerAudio.PlayOneShot(dashClip,0.5f);
            //playerAudio.Play();
            currentStamina = 0;
            this.gameObject.layer = 15;
            
        }
    }
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.F) )
        {
            
            if (isInWaveTeleport)
            {
                TeleportToShop();

            }
            if (isInShopTeleport)
            {
                TeleportToWave();

            }


        }
        




        staminaSlider.value = Mathf.Lerp(staminaSlider.value, currentStamina, Time.deltaTime * 3);
        Dash();

        moveX = Input.GetAxisRaw("Horizontal");

        moveY = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(moveX * velocidadeAtual, moveY * velocidadeAtual);
        rigid.velocity.Normalize();
        
        if (moveX != 0 || moveY !=0)
        {
            anim.SetBool("Run", true);
        }
        if (moveX == 0 && moveY == 0)
        {
            anim.SetBool("Run", false);
        }
        
        if (moveX < 0 && facemouse.directionX < 0)
        {
            playerSprite.flipX = true;
        }
        if (moveX > 0 && facemouse.directionX > 0)
        {
            playerSprite.flipX = false;
        }

       
    }

    private void TeleportToWave()
    {
        playerAudio.PlayOneShot(portalClip, 0.5f);
        damageImage.color = Color.white;
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, 16 * Time.deltaTime);
        transform.position = wavePosition.transform.position;
        isInShopTeleport = false;
    }

    private void TeleportToShop()
    {
        playerAudio.PlayOneShot(portalClip, 0.5f);
        damageImage.color = Color.white;
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, 16 * Time.deltaTime);
        transform.position = shopPosition.transform.position;
        isInWaveTeleport = false;
    }

    public void Velocidade()
    {
        velocidadeAtual = velocidade + experience.speedBonus;
    }

    public void SlowEffect(float poisonSlow)
    {
        isSlow = true;
        canDash = false;
        //Instantiate(poisonEffect, posionPos.transform.position, transform.rotation);
        velocidadeAtual = poisonSlow;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

        Invoke("ReturnToNormal", 3f);


    }

    public IEnumerator ColorChangeToRed()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(playerHealth.burnTime);
        this.gameObject.GetComponent<SpriteRenderer>().color = originalColor;
    }

    void ReturnToNormal()
    {
        canDash = true;
        isSlow = false;
        Velocidade();
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike" && playerHealth.hasSteelBoots)
        {
            steelBootsEffect.SetActive(true);
        }
        if (collision.gameObject.tag == "ShopTeleport")
        {
            isInShopTeleport = true;
        }
        if (collision.gameObject.tag == "WaveTeleport")
        {
            isInWaveTeleport = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike" && playerHealth.hasSteelBoots)
        {
            steelBootsEffect.SetActive(false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ShopTeleport")
        {
            isInShopTeleport = false;
        }
        if (other.gameObject.tag == "WaveTeleport")
        {
            isInWaveTeleport = false;
        }
    }

}
