using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vida : MonoBehaviour
{

    public float vida;
    public float dash;
    Text text;

    GameObject player;
    Experience experience;
    [SerializeField] bool isDash;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        text = GetComponent<Text>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDash)
        {
            dash = experience.dashPoints;
            text.text = "DASH: " + dash;
        }
        else
        {
            vida = experience.lifePoints;
            text.text = "Vida: " + vida;
        }

    }
}
