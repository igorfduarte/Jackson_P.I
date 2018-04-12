using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{

    public float atributo;
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
        atributo = experience.experiencePoints;
        text.text = "Atributos: " + atributo;
    }
}
