using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour {
    Slider slider;
    GameObject player;
    Experience experience;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        experience = player.GetComponent<Experience>();
        slider = GetComponent<Slider>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        slider.maxValue = experience.expMax;
        slider.value = Mathf.Lerp(experience.expAtual, slider.maxValue, Time.deltaTime);
    }
}
