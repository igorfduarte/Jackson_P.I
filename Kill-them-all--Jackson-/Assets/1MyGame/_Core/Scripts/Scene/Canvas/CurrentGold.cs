using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurrentGold : MonoBehaviour
{

    public float value;
    Text text;

    GameObject player;
    Shop experience;
    [SerializeField] string texto;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Shop");
        experience = player.GetComponent<Shop>();
        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        value = experience.goldAtual;
        text.text = texto + value;
    }
}
