using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : MonoBehaviour {
    EnemyMovement movement;
    [SerializeField] GameObject enemyCamera;
    
    Rigidbody2D rigid;
    
    AudioSource introAudio;
    public AudioClip laugh;

	// Use this for initialization
	void Awake () {
        introAudio = GetComponent<AudioSource>();
        rigid = GetComponent<Rigidbody2D>();
        movement = GetComponent<EnemyMovement>();
        movement.enabled = false;
        enemyCamera.SetActive(true);
        
        StartCoroutine("Intro");
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    IEnumerator Intro()
    {
        introAudio.PlayOneShot(laugh, 1);
        yield return new WaitForSeconds(2f);
        Invoke("Move", 0);
        yield return new WaitForSeconds(4f);
        movement.enabled = true;
        enemyCamera.SetActive(false);
        CancelInvoke("Move");

    }
    void Move()
    {
        rigid.velocity = new Vector2(0, -3);

        
    }
}
