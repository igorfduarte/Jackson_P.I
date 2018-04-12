using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeExplode : MonoBehaviour {

    GameObject player;
    GameObject enemy;
    ChasePlayer move;
    PlayerHealth playerHealth;
    EnemySlimeHealth enemyHealth;
    public int attackDamage = 30;
    AudioSource slimeAudio;
    float damageRadius = 5f;
    float dis;
    


    


    public GameObject slimeFloorPrefab;
    public GameObject endPos;

    Animator anim;

    // Use this for initialization
    void Start () {
        slimeAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        
        move =GetComponent<ChasePlayer>();
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemySlimeHealth>();
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {

            
            GoingToExplode();



        }

    }

    public void Explode()
    {
        dis = Vector3.Distance(player.transform.position, transform.position);
        if (dis <= damageRadius)
        {
            playerHealth.TakeDamage(attackDamage);
        }
        Destroy(this.gameObject);
        GameObject slimeFloor = (GameObject)Instantiate(slimeFloorPrefab, endPos.transform.position, transform.rotation);
        Destroy(slimeFloor, 5f);
    }

   public void GoingToExplode()
    {
        enemyHealth.isDead = true;
        slimeAudio.Stop();
        slimeAudio.clip = enemyHealth.slimeDeathClip;
        slimeAudio.Play();
        move.speed = 0;
        
        anim.SetTrigger("SlimeExplode");

        Invoke("Explode", 1.8f);
    }


}
