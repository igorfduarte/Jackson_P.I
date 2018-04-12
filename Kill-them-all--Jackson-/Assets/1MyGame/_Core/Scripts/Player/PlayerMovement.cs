using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {
    [SerializeField] GameObject wavePosition;
    [SerializeField] GameObject shopPosition;
    bool isInShopTeleport;
    bool isInWaveTeleport;
    [SerializeField]float velocidade = 6f;
    float currentStamina;
    [SerializeField] float maxStamina = 100;
    [SerializeField] float timeToFullStamina;
    float velocidadeOriginal;
    float velocidadeAtual;
    [SerializeField] float velocidadeDash;
    float tempoDash = 0.2f;
    bool estaDandoDash;
	float moveX;
	float moveY;
	Rigidbody2D rigid;
    Animator anim;
    AudioSource playerAudio;
    public AudioClip dashClip;
    public GameObject poisonEffect;
    public GameObject steelBootsEffect;
    public Slider staminaSlider;

    
    
    PlayerHealth playerHealth;

    Experience experience;
    
    public bool isSlow;
    bool canDash = true;

    [SerializeField]GameObject teleportToWave;
    [SerializeField]GameObject teleportToShop;
    Teleport teleport;




    void Start () {
        
        
        experience = GetComponent<Experience>();
        currentStamina = maxStamina;
        velocidadeOriginal = velocidade;
		rigid = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        
        playerHealth = GetComponent<PlayerHealth>();
        Velocidade();




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
            playerAudio.clip = dashClip;
            playerAudio.Play();
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
                transform.position = shopPosition.transform.position;
                isInWaveTeleport = false;
                

            }
            if (isInShopTeleport)
            {
                transform.position = wavePosition.transform.position;
                isInShopTeleport = false;
                
            }
            
            
        }
        




        staminaSlider.value = Mathf.Lerp(staminaSlider.value, currentStamina, Time.deltaTime * 3);
        Dash();

        moveX = Input.GetAxisRaw("Horizontal");

        moveY = Input.GetAxisRaw("Vertical");

        rigid.velocity = new Vector2(moveX * velocidadeAtual, moveY * velocidadeAtual);
        rigid.velocity.Normalize();

        /*
        if (moveX != 0)
        {
            anim.SetFloat(("Horizontal"), Mathf.Abs(moveX));
        }
        else if (moveX == 0)
        {
            anim.SetFloat(("Horizontal"),0);
        }
        if (moveY != 0)
        {
            anim.SetFloat(("Vertical"), Mathf.Abs(moveY));
        }
        else if (moveY == 0)
        {
            anim.SetFloat(("Vertical"),0);
        }
        */
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
