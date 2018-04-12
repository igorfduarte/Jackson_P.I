using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiro : MonoBehaviour {
    // VARIAVEIS
    #region
    //[SerializeField] Transform startPosistion;
    Weapon weapon;




    [SerializeField] GameObject balaPrefab;
    public float cooldown = 0.5f;
    //float timerPool;

    public Pooling poolAk;
    public Pooling poolShotgun;
    public Pooling poolVector;
    public Pooling poolPistol;

    bool isReloading;





    public int ammoRaygun = 100;
    public int ammoAK;
    public CameraFollow cameraShake;

    float timer;
    public float spellSpeed;
    public GameObject rayShoot;
    
    public GameObject bulletPistol;
    public GameObject bulletAK;
    public GameObject bulletGL;
    public GameObject shotgunBulletPrefab;
    public GameObject ultimateBomb;
    public GameObject slowSpell;
    public GameObject startPos;
    public Transform[] shotgunStartPos;
    public Transform[] vectorStartPos;
    public GameObject ultPos;
    [SerializeField] float timeBetweenAttacks;
    float timeBetweenAttacksUlt = 3.4f;
    public Transform[] spawnPoints;
    Transform trans;
    
    
    
    
    public AudioClip[] noManaClip;
    public AudioClip emptyClip;
    AudioSource gunAudio;
    public bool isParticle;
    public float tempoUlt = 2.5f;

    public bool playKame;
    public bool playAk;
    public bool playIce;
    bool isUlt;
    bool isUlting;

    public float pistolDamage = 2f;
    public float akDamage = 1.75f;
    public float rayGunDamage = 3.5f;
    public float shotgunDamage = 5;

    [SerializeField]AudioClip reloadClip;
    

    ParticleSystem gunParticles;

    Animator anim;


    public float flashSpeed = 5f;
    public Color ultimateFlashColor;
    public Color iceSlowFlashColor;
    public Image damageImage;

    
    PlayerHealth playerHealth;
    Player player;
    
    //ChangeWeapon weapon;

    GameObject jogador;

    int shakePercent;

    public GameObject audioSource;
    GameObject playerVida;

    GameObject shop;
    Shop shopClass;

#endregion

    void AtirarNormalWeapon()
    {
       
        for (int y = 0; y < weapon.startPos.Length; y++)
        {
            GameObject possoUsar = weapon.poolWeapon.GetPooledObject();
            if (possoUsar != null)
            {
                possoUsar.transform.position = weapon.startPos[y].position;
                possoUsar.transform.rotation = weapon.startPos[y].rotation;
                possoUsar.SetActive(true);

            }
            timer = 0;
            weapon.currentAmmo--;

            
        }
        gunAudio.PlayOneShot(weapon.weaponClip, 0.25f);
    }

    void AtirarRandomWeapon()
    {
        
        gunAudio.PlayOneShot(weapon.weaponClip, 0.25f);
        int spawnPointIndex = Random.Range(0, weapon.startPos.Length);
        GameObject possoUsar = weapon.poolWeapon.GetPooledObject();
        if (possoUsar != null)
        {
            possoUsar.transform.position = weapon.startPos[spawnPointIndex].position;
            possoUsar.transform.rotation = weapon.startPos[spawnPointIndex].rotation;
            possoUsar.SetActive(true);

        }
        weapon.currentAmmo--;
        timer = 0f;
    }
 
    void Start () {

        shop = GameObject.FindGameObjectWithTag("Shop");
        shopClass = shop.GetComponent<Shop>();
		//spawnPoints = GetComponent<Transform> ();
        player = GetComponent<Player>();
        trans = GetComponent<Transform>();
        gunAudio = GetComponent<AudioSource>();                     
        isUlt = false;
        anim = GetComponent<Animator>();
        gunParticles = GetComponent<ParticleSystem>();


    }

	
	// Update is called once per frame
	void Update ()
    {

        jogador = GameObject.FindGameObjectWithTag("Weapon");
        weapon = jogador.GetComponent<Weapon>();
        if (timer >= weapon.fireRate && Input.GetMouseButton(0) && weapon.currentAmmo > 0 && weapon.maxAmmo >0 && !isUlting && weapon.fixPos && !isReloading)
        {

            AtirarNormalWeapon();
            UpdateAmmoCanvas();
        }

        if (timer >= weapon.fireRate && Input.GetMouseButton(0) && weapon.currentAmmo > 0 && weapon.maxAmmo > 0 && !isUlting && weapon.randomPos && !isReloading)
        {

            AtirarRandomWeapon();
            UpdateAmmoCanvas();
        }

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            isReloading = true;
            StartCoroutine("Reload");
            anim.Play("Reload");
        }

        if (Input.GetMouseButtonDown(0) && weapon.currentAmmo<= 0 || Input.GetMouseButtonDown(0) && weapon.maxAmmo <= 0)
        {
            gunAudio.PlayOneShot(emptyClip, 0.35f);
        }


        
        playerVida = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerVida.GetComponent<PlayerHealth>();


        if (playerHealth.currentHealth <= 0)
        {
            gunAudio.mute = true;
        }
        else
        {
            gunAudio.mute = false;
        }

        timer += Time.deltaTime;
        //TiroControle();

        if (timer >= timeBetweenAttacks && Input.GetKeyDown(KeyCode.E) && shopClass.iceCount > 0)
        {
            playIce = true;
            IceSlow();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            playIce = false;
        }

    }

    /*public void TiroControle()
    {
        if (timer >= 0.8f && Input.GetMouseButtonDown(0) && ammoRaygun >= 1 && !isUlting && weapon.hasRaygun == true)
        {

            TiroRayGun();
        }

        if (timer >= 0.8f && Input.GetMouseButtonDown(0) && ammoRaygun >= 1 && !isUlting && weapon.hasShotgun == true)
        {

            TiroShotGun();
        }
        else if (timer >= 0.05 && Input.GetMouseButton(0) && weapon.hasVector == true && ammoAK >= 1 && !isUlting)
        {

            TiroVector();
        }

        if (timer >= timeBetweenAttacks && Input.GetKeyDown(KeyCode.E) && playerHealth.currentEnergy >= 15)
        {
            playIce = true;
            IceSlow();
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            playIce = false;
        }

        if (timer >= 0.33f && Input.GetMouseButton(0) && weapon.hasPistol == true)
        {

            TiroPistol();
        }
        
        else if (timer >= timeBetweenAttacks && Input.GetMouseButton(0) && weapon.hasAk == true && ammoAK >= 1 && !isUlting)
        {

            TiroAK();

        }

        if (timer >= timeBetweenAttacks && Input.GetKeyDown(KeyCode.R) && playerHealth.currentEnergy >= 100 && !isUlt)
        {
            isUlting = true;
            playKame = true;
            anim.SetTrigger("Ultimate");

            Invoke("Ultimate", 2.5f);
            //Ultimate();

        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            playKame = false;
        }

        if (playerHealth.currentEnergy < 90 && Input.GetKeyDown(KeyCode.R))
        {
            int spawnPointIndex = Random.Range(0, noManaClip.Length);

            gunAudio.clip = noManaClip[spawnPointIndex];

            gunAudio.Play();
        }
    }
    */

    // FUNCOES DE TIROS
    /*#region
        
    public void TiroPistol()
    {
        GameObject possoUsar = poolPistol.GetPooledObject();
        if (possoUsar != null)
        {
            possoUsar.transform.position = startPos.transform.position;
            possoUsar.transform.rotation = startPos.transform.rotation;
            possoUsar.SetActive(true);

        }
        
        timer = 0f;
        //UpdateAmmoCanvas();

        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        //GameObject tiroPistol = (GameObject)Instantiate(bulletPistol, startPos.transform.position, startPos.transform.rotation);
        //GameObject tiroPistol = (GameObject)Instantiate(bulletPistol, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
       // Destroy(tiroPistol, 1.5f);
    }


    public void TiroShotGun()
    {
        for (int y = 0; y < shotgunStartPos.Length; y++)
        {
            GameObject possoUsar = poolShotgun.GetPooledObject();
            if (possoUsar != null)
            {
                possoUsar.transform.position = shotgunStartPos[y].position;
                possoUsar.transform.rotation = shotgunStartPos[y].rotation;
                possoUsar.SetActive(true);

            }
            
            //GameObject tiroPistol = (GameObject)Instantiate(shotgunBulletPrefab, shotgunStartPos[y].position, shotgunStartPos[y].rotation);
            // Destroy(tiroPistol.gameObject, 0.35f);
            timer = 0;

        }
    }


    public void TiroVector()
    {
        int spawnPointIndex = Random.Range(0, vectorStartPos.Length);
        GameObject possoUsar = poolVector.GetPooledObject();
        if (possoUsar != null)
        {
            possoUsar.transform.position = vectorStartPos[spawnPointIndex].position;
            possoUsar.transform.rotation = vectorStartPos[spawnPointIndex].rotation;
            possoUsar.SetActive(true);

        }
        
        timer = 0f;
        
        //GameObject tiroPistol = (GameObject)Instantiate(bulletPistol, vectorStartPos[spawnPointIndex].position, vectorStartPos[spawnPointIndex].rotation);
       // Destroy(tiroPistol, 0.4f);
    }


    public void TiroGl()
    {
        timer = 0f;
       
        GameObject novoSpell = (GameObject)Instantiate(bulletGL, startPos.transform.position, startPos.transform.rotation);

        Destroy(novoSpell, 3);

        
    }


    public void TiroAK()
    {

        GameObject possoUsar = poolAk.GetPooledObject();
        if (possoUsar != null)
        {
            possoUsar.transform.position = startPos.transform.position;
            possoUsar.transform.rotation = startPos.transform.rotation;
            possoUsar.SetActive(true);

        }
      
        timer = 0f;
        ammoAK--;

  
        
    }


    void TiroRayGun()
    {
        ammoRaygun--;
        timer = 0;
 
        gunAudio.Play();
        GameObject novoSpell = (GameObject)Instantiate(rayShoot, startPos.transform.position, playerVida.transform.rotation);
        //novoSpell.GetComponent<Rigidbody2D>().AddForce(playerVida.transform.up *spellSpeed);
        novoSpell.GetComponent<Rigidbody2D>().velocity = playerVida.transform.up * spellSpeed;
        Destroy(novoSpell, 2f);
    }

    #endregion
    */
    // MAGIAS
    #region
    void UltimateFlash()
    {
        damageImage.color = ultimateFlashColor;
    }

    void IceSlowFlash()
    {
        damageImage.color = iceSlowFlashColor;
        //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
    }

    void IceSlow()
    {
        Invoke("IceSlowFlash", 2.4f);
        timer = 0f;
        GameObject slow = (GameObject)Instantiate(slowSpell, ultPos.transform.position, trans.rotation);
        shopClass.iceCount--;
        //Invoke("StopIceSlow", 0f);

    }

    void Ultimate()
    {
        InvokeRepeating("UltimateFlash", 0f, 0.1f);
        damageImage.color = ultimateFlashColor;
        isUlt = true;
        playerHealth.currentEnergy = 0;
        playerHealth.energySlider.value = playerHealth.currentEnergy;
        GameObject ultimate = (GameObject)Instantiate(ultimateBomb, ultPos.transform.position, trans.rotation);
        Invoke("StopUltimate", tempoUlt);

        Destroy(ultimate, 6);
    }

    void StopUltimate()
    {
        isUlting = false;
        damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        gunParticles.Stop();

        isUlt = false;
        CancelInvoke("UltimateFlash");

    }
#endregion


    // MUNICAO
    void UpdateAmmoCanvas()
   {
       
            ScoreManager.score = weapon.currentAmmo;
               
    }
    IEnumerator Reload()
    {
        if (weapon.maxAmmo >= weapon.maxAmmoInHand)
        {
            gunAudio.PlayOneShot(reloadClip, 0.3f);
            yield return new WaitForSeconds(weapon.reloadTime);


            weapon.maxAmmo -= (weapon.maxAmmoInHand - weapon.currentAmmo);
            weapon.currentAmmo = weapon.maxAmmoInHand;
            isReloading = false;
        }
        
       




    }
    
    

   
    


}