using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelAtual : MonoBehaviour
{

    public float level;
    Text text;

    GameObject player;
    Experience experience;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        text = GetComponent<Text>();
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        level = experience.expIndex;
        text.text = "" + level;
    }
}
