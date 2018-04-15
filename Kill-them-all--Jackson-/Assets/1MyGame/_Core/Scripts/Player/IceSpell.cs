using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpell : MonoBehaviour
{
    public bool isFire;
    public bool isIce;
    [SerializeField] float speed = 10f;
    [SerializeField] float radius;
    
    public float effectDuration;
    public float delay = 4f;
    float countdown;
    bool hasExploded = false;
    public GameObject explosionEffect;
    public GameObject fireExplosion;
    
    GameObject enemy;
    float speedSlow = 1f;
   
    GameObject player;
    GameObject cameraAudio;
    AudioSource audioSource;

    public GameObject[] enemiesInRange;
    
    AudioSpell audioSpell;
    EnemyMovement move;
    EnemyHealth enemyHealth;
    ChasePlayer chase;
    EnemySlimeHealth slimeHealth;
    void Start()
    {
        cameraAudio = GameObject.FindGameObjectWithTag("CameraAudio");
        audioSpell = cameraAudio.GetComponent<AudioSpell>();
        audioSource = cameraAudio.GetComponent<AudioSource>();
        this.GetComponent<Rigidbody2D>().AddForce(transform.up * speed);
        countdown = delay;
        //  enemy = FindObjectOfType<Enemy>();
        



    }
    void Update()
    {
        
        /*
        Vector3 pos = transform.position;
        Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
        pos += transform.rotation * velocity;
        transform.position = pos;
        */
        countdown -= Time.deltaTime;
        

        if (countdown <= 0 && !hasExploded)
        {
            StartCoroutine("Explode");
            hasExploded = true;
        }
    
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy" && !hasExploded)
        {
            StartCoroutine("Explode");
            hasExploded = true;
        }

        if (col.gameObject.tag == "EnemyChase" && !hasExploded)
        {
            StartCoroutine("Explode");
            hasExploded = true;
        }

        if (col.gameObject.tag == "Wall" && !hasExploded)
        {
            StartCoroutine("Explode");
            hasExploded = true;
        }

    }

    IEnumerator Explode()
    {
        
        if (isIce)
        {
            audioSource.PlayOneShot(audioSpell.breakClip, 0.25f);
            yield return new WaitForSeconds(0.3f);
            audioSource.PlayOneShot(audioSpell.iceSlow, 0.6f);
            GameObject novoexplosionEffect = IceEffect();
            hasExploded = false;
            Destroy(gameObject);
            Destroy(novoexplosionEffect, effectDuration);
        }
        if (isFire)
        {
            audioSource.PlayOneShot(audioSpell.breakClip, 0.25f);
            GameObject novoFireExplosion = (GameObject)Instantiate(fireExplosion, transform.position, transform.rotation);
            Destroy(novoFireExplosion, 2f);         
            

            yield return new WaitForSeconds(0.25f);
            
            GameObject novoexplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
            //GameObject novoexplosionEffect = FireEffect();
            hasExploded = false;
            Destroy(gameObject);
            Destroy(novoexplosionEffect, effectDuration);
        }

    }
    /*GameObject FireEffect()
    {
        GameObject novoexplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, 9 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider2D nearbyObject in col)
        {

            if (nearbyObject.transform.tag == "Enemy")
            {
                
                enemyHealth = nearbyObject.GetComponent<EnemyHealth>();
                move = nearbyObject.GetComponent<EnemyMovement>();               
                move.ColorChangeToRed();
                enemyHealth.StartCoroutine("FireDamage");
                print("ColorChangeToRed");

            }

            if (nearbyObject.transform.tag == "EnemyChase")
            {
                slimeHealth = nearbyObject.GetComponent<EnemySlimeHealth>();
                chase = nearbyObject.GetComponent<ChasePlayer>();

                chase.ColorChangeToRed();

                slimeHealth.StartCoroutine("FireDamage");
                
                print("ColorChangeToBlue");
            }

        }

        return novoexplosionEffect;
    }
    */
     GameObject IceEffect()
    {
        GameObject novoexplosionEffect = (GameObject)Instantiate(explosionEffect, transform.position, transform.rotation);
        Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, radius, 9 << LayerMask.NameToLayer("Enemy"));

        foreach (Collider2D nearbyObject in col)
        {



            if (nearbyObject.transform.tag == "Enemy")
            {
                move = nearbyObject.GetComponent<EnemyMovement>();

                print("ColorChangeToBlue");
                move.ColorChangeToBlue();
                //move.ColorChangeToBlue();
                move.SlowEffect(speedSlow);
                //move.SlowEffect(speedSlow);
            }

            if (nearbyObject.transform.tag == "EnemyChase")
            {
                chase = nearbyObject.GetComponent<ChasePlayer>();
                print("ColorChangeToBlue");
                chase.ColorChangeToBlue();
                //move.ColorChangeToBlue();
                chase.SlowEffect(speedSlow);
                //move.SlowEffect(speedSlow);
            }





        }

        return novoexplosionEffect;
    }

    void OnDrawGizmos()
    {
        // Draw attack sphere 
        Gizmos.color = new Color(255f, 0, 0, .5f);
        Gizmos.DrawWireSphere(transform.position, radius);

    }
}
