using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public float vida;
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
        vida = experience.lifePoints;
        text.text = "Vida: " + vida;
    }
}
