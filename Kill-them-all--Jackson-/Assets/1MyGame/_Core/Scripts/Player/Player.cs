using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization

    GameObject player;
    WeaponSwitch weapon;
    AudioSource playerAudio;
    public AudioClip takeAK;
    public AudioClip takeRay;

    // Use this for initialization
    void Start () {



    }

	// Update is called once per frame
	void Update () {
        playerAudio = GetComponent<AudioSource>();
        player = GameObject.FindGameObjectWithTag("Player");
        weapon = player.GetComponentInChildren<WeaponSwitch>();


    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "AK47")
        {
            playerAudio.PlayOneShot(takeAK, 0.75f);
            weapon.hasAK = true;
            Destroy(other.gameObject);

        }
        if (other.gameObject.tag == "RayGun")
        {
            playerAudio.PlayOneShot(takeRay, 0.75f);
            weapon.hasRayGun = true;
            Destroy(other.gameObject);

        }
  

    }











}
