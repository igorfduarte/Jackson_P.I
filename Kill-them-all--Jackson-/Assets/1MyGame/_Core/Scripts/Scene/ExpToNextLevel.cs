using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpToNextLevel : MonoBehaviour {

    public float exp; // exp to next level
    Text text;

    GameObject player;
    Experience experience;
    

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        text = GetComponent<Text>();
        exp = 0;
    }

    // Update is called once per frame
    void Update()
    {
        exp = experience.expToNextLevel;
        text.text = "Exp To Next Level: " + exp;
    }
}
