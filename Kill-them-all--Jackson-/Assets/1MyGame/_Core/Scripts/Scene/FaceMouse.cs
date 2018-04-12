using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceMouse : MonoBehaviour {
    Animator anim;
    Vector3 pos;
    public Vector2 direction;

   
    bool toFace;
	
	void Start () {
        anim = GetComponent<Animator>();
        

	}
	
	

	void Update () {

       
		faceMouse ();
        
        pos = transform.position;
       
	}

	void faceMouse(){
		Vector3 mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);

		direction = new Vector2 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

		transform.up = direction;



        

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
        
        
	}
    
}
