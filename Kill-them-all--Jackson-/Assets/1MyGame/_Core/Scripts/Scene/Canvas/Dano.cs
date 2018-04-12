using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dano : MonoBehaviour
{

    public float dano;
    Text text;

    GameObject player;
    Experience experience;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dano = experience.damagePoints;
        text.text = "Dano: " + dano;
    }
}
