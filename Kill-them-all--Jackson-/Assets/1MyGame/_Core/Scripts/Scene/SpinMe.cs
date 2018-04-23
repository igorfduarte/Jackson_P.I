using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinMe : MonoBehaviour
{


    [SerializeField] float zRotationsPerMinute = 20f;

    Tiro tiro;
    GameObject player;
    [SerializeField] Transform controle;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        
        tiro = player.GetComponent<Tiro>();

        if (tiro.isReloading)
        {
            if (player.GetComponent<SpriteRenderer>().flipX)
            {
                float zDegreesPerFrame = Time.deltaTime / 60 * 360 * -zRotationsPerMinute;
                transform.RotateAround(transform.position, transform.forward, zDegreesPerFrame);
            }
            else
            {
                float zDegreesPerFrame = Time.deltaTime / 60 * 360 * zRotationsPerMinute;
                transform.RotateAround(transform.position, transform.forward, zDegreesPerFrame);
            }
            
        }
        else
        {
            this.transform.rotation = controle.rotation;
        }
       
    }
}
