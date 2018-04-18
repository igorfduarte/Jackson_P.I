using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    Animator anim;
    Vector3 pos;
    public Vector2 direction;
    PlayerMovement playerMovement;
    
    SpriteRenderer weaponSprite;
    SpriteRenderer armSprite;
    SpriteRenderer playerSprite;

    GameObject weaponPos;
    public float directionX;
    public GameObject player;
    public GameObject arm;
    GameObject weapon;
    public GameObject armPosRight;
    public GameObject armPos2;


    bool toFace;
	
	void Start () {
        playerMovement = GetComponentInParent<PlayerMovement>();
        //anim = GetComponent<Animator>();
       
        armSprite = arm.GetComponent<SpriteRenderer>();
        
        playerSprite = player.GetComponent<SpriteRenderer>();
        

	}
	
	

	void Update () {

       
		faceMouse ();
        Flip();
        
        pos = transform.position;
       
	}

    void Flip()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        weaponSprite = weapon.GetComponent<SpriteRenderer>();
        if (playerSprite.flipX )
        {

            weaponPos = armPos2;
            arm.transform.position = weaponPos.transform.position;
            armSprite.flipX = true;
            weaponSprite.flipY = true;
            

            
        }
        else
        {
            weaponPos = armPosRight;
            arm.transform.position = weaponPos.transform.position;
            armSprite.flipX = false;
            weaponSprite.flipY = false;
        }
    }

	void faceMouse(){
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

    



        directionX = (mousePosition.x - transform.position.x);

        direction = new Vector2 (directionX, mousePosition.y - transform.position.y);

		transform.up = direction;
        


        if (directionX < -4f  && !playerMovement.isIdle)
        {
            
            playerSprite.flipX = true;
            
        }
        else if( directionX > 4f && !playerMovement.isIdle)
        {
            
            playerSprite.flipX = false;
        }



     /*   

            if (mousePosition.x < pos.x)
            {
                anim.SetFloat(("Horizontal"), -1);
            }
            else if (mousePosition.x > pos.x)
            {
                anim.SetFloat(("Horizontal"), 1);
            }
            if (mousePosition.y < pos.y)
            {
                anim.SetFloat(("Vertical"), -1);
            }
            else if (mousePosition.y > pos.y)
            {
                anim.SetFloat(("Vertical"), 1);
            }
        
      */  
	}
    
}
