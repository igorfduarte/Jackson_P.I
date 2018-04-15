using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiro : MonoBehaviour {
    // VARIAVEIS
    #region
    //[SerializeField] Transform startPosistion;

    [SerializeField] GameObject balaPrefab;
    [SerializeField] float timeBetweenAttacks;
    [SerializeField] AudioClip reloadClip;   
    
    //float timerPool;
    public Pooling poolAk;
    public Pooling poolShotgun;
    public Pooling poolVector;
    public Pooling poolPistol;

    public float cooldown = 0.5f;
    public int ammoRaygun = 100;
    public int ammoAK;
    public GameObject arm;
    public GameObject rayShoot;   
    public GameObject bulletPistol;
    public GameObject bulletAK;
    public GameObject bulletGL;
    public GameObject shotgunBulletPrefab;
    public GameObject ultimateBomb;
    public GameObject slowSpell;
    public GameObject molotov;
    public GameObject startPos;
    public GameObject ultPos;
    public GameObject audioSource;

    public CameraFollow cameraShake;
    public Transform[] shotgunStartPos;
    public Transform[] vectorStartPos;
    public Transform[] spawnPoints;
    public AudioClip emptyClip;
    public AudioClip throwClip;
    public Color ultimateFlashColor;
    public Color iceSlowFlashColor;
    public Image damageImage;

    Weapon weapon;
    Shop shopClass;
    PlayerHealth playerHealth;
    Player player;

    Transform trans;
    AudioSource gunAudio;
    ParticleSystem gunParticles;
    Animator anim;
    GameObject jogador;
    GameObject playerVida;
    GameObject shop;
   

    public bool isParticle;
    public bool playAk;
    public bool playIce;
    public bool molotovActive;
    public bool icePotionActive;
    public float flashSpeed = 5f;

    int condicao;
    int ammoLimit;
    float timer;
    public float spellSpeed;
    bool isUlt;
    bool isUlting;
   public bool isReloading;
    int shakePercent;
    float timeBetweenAttacksUlt = 3.4f;

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
        icePotionActive = true;
        shop = GameObject.FindGameObjectWithTag("Shop");
        shopClass = shop.GetComponent<Shop>();
		//spawnPoints = GetComponent<Transform> ();
        player = GetComponent<Player>();
        trans = arm.GetComponent<Transform>();
        gunAudio = GetComponent<AudioSource>();                     
        isUlt = false;
        anim = GetComponent<Animator>();
        gunParticles = GetComponent<ParticleSystem>();


    }

	
	// Update is called once per frame
	void Update ()
    {
        playerVida = GameObject.FindGameObjectWithTag("Player");
        playerHealth = playerVida.GetComponent<PlayerHealth>();
        timer += Time.deltaTime;
        jogador = GameObject.FindGameObjectWithTag("Weapon");
        weapon = jogador.GetComponent<Weapon>();
       
        if (timer >= weapon.fireRate && Input.GetMouseButton(0) && weapon.currentAmmo > 0  && weapon.fixPos && !isReloading)
        {

            AtirarNormalWeapon();
            UpdateAmmoCanvas();
        }

        if (timer >= weapon.fireRate && Input.GetMouseButton(0) && weapon.currentAmmo > 0  && weapon.randomPos && !isReloading)
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

        if (Input.GetMouseButton(0) && weapon.currentAmmo<= 0 && timer > 0.5f && !isReloading || Input.GetMouseButton(0) && weapon.maxAmmo <= 0 && timer>0.5f && !isReloading)
        {
            gunAudio.PlayOneShot(emptyClip, 0.5f);
            timer = 0;
        }      

        /*
        if (timer >= 0.35 && Input.GetKeyDown(KeyCode.E) && shopClass.iceCount > 0)
        {
            gunAudio.PlayOneShot(throwClip, 0.13f);
            timer = 0;
            playIce = true;
            IceSlow();
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            playIce = false;
        }

        if (timer >= 0.35 && Input.GetKeyDown(KeyCode.Q) && shopClass.molotovCount > 0)
        {
            gunAudio.PlayOneShot(throwClip, 0.13f);
            playIce = true;
            Molotov();
            timer = 0;
        }
        */
        if ( Input.GetKeyDown(KeyCode.Q))
        {
            molotovActive = !molotovActive;
            icePotionActive = !icePotionActive;


        }

        if (timer >= 0.25 && Input.GetKeyDown(KeyCode.E) && shopClass.iceCount > 0)
        {
            if (icePotionActive && shopClass.iceCount > 0)
            {
                gunAudio.PlayOneShot(throwClip, 0.13f);
                timer = 0;
                playIce = true;
                IceSlow();
            }
            if (molotovActive && shopClass.molotovCount >0)
            {
                gunAudio.PlayOneShot(throwClip, 0.13f);
                playIce = true;
                Molotov();
                timer = 0;
            }

        }


        if (playerHealth.currentHealth <= 0)
        {
            gunAudio.mute = true;
        }
        else
        {
            gunAudio.mute = false;
        }

    }
    void Molotov()
    {
        int spawnPointIndex = Random.Range(0, weapon.startPos.Length);
        GameObject newMolly = (GameObject)Instantiate(molotov, ultPos.transform.position, trans.rotation);
        shopClass.molotovCount--;

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
        //Invoke("StopUltimate", tempoUlt);

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
    /*
    IEnumerator Reload()
    {
        if (weapon.maxAmmo >= weapon.currentAmmo)
        {
            gunAudio.PlayOneShot(reloadClip, 0.3f);
            yield return new WaitForSeconds(weapon.reloadTime);
            ammoLimit = weapon.maxAmmoInHand - weapon.currentAmmo;
            if ((weapon.maxAmmo - ammoLimit) < 0)
            {
                weapon.currentAmmo += weapon.maxAmmo;
                weapon.maxAmmo = 0;
            }
            else
            {
                weapon.currentAmmo += ammoLimit;
                weapon.maxAmmo -= ammoLimit;
            }
            isReloading = false;
        }
        
        if (weapon.maxAmmo >= weapon.maxAmmoInHand)
        {
            
            yield return new WaitForSeconds(weapon.reloadTime);


            weapon.maxAmmo -= (weapon.maxAmmoInHand - weapon.currentAmmo);
            weapon.currentAmmo = weapon.maxAmmoInHand;
            
        }
        
        if (weapon.maxAmmo < weapon.currentAmmo)
        {
            ammoLimit = weapon.maxAmmoInHand - weapon.currentAmmo;

            weapon.maxAmmo -= ammoLimit;

            if (weapon.maxAmmo <= 0)
            {
                weapon.maxAmmo = 0;
            }
            else
            {
                weapon.currentAmmo += ammoLimit;
            }
            

 
         
           

        }
        if (weapon.maxAmmo <=0)
        {
            isReloading = false;
        }
       
    */

    IEnumerator Reload()
    {
        yield return new WaitForSeconds(weapon.reloadTime);
        ammoLimit = weapon.maxAmmoInHand - weapon.currentAmmo;


        condicao = weapon.maxAmmo - ammoLimit;

        if (condicao < 0)
        {
            weapon.currentAmmo += weapon.maxAmmo;
            weapon.maxAmmo = 0;
            isReloading = false;
        }
        else
        {
            weapon.currentAmmo += ammoLimit;
            weapon.maxAmmo -= ammoLimit;
            isReloading = false;


        }
        


    }
    
    

   
    


}