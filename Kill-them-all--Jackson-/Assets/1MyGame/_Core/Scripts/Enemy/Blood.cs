using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    [SerializeField]
     Sprite blood2;
    [SerializeField]
     Sprite blood3;
   
   // GameObject transPos;

    

    
    float timer;
    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;


        if (timer >= 7.5f && timer<= 9.5f)
        {
                       
            this.gameObject.GetComponent<SpriteRenderer>().sprite = blood2;
        }
        if (timer >= 15.5f && timer <= 17f)
        {          

            this.gameObject.GetComponent<SpriteRenderer>().sprite = blood3;
            Destroy(this.gameObject, 8);
        }



    }

    

    
}
