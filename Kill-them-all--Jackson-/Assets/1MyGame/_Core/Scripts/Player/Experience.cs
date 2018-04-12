using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour {

    public float expAtual = 0;
    public int expIndex = 1;
    public float expMax = 100;
    public float expMultiplier;
    public float expToNextLevel;

    public int experiencePoints;
    public int damagePoints=1;
    public float speedPoints=1;
    public float lifePoints=1;

    public float damageBonus;
    public float speedBonus =1;
    public float lifeBonus= 1;

    [SerializeField] float damageMultiplier;
    [SerializeField] float speedMultiplier;
    [SerializeField] float lifeMultiplier;

    AudioSource audioSource;
    [SerializeField] AudioClip lvlupClip;
    [SerializeField] GameObject lvlParticle;
    [SerializeField] GameObject lvlAnim;






    

    // Use this for initialization
    void Start () {

        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
       expToNextLevel = expMax - expAtual;

        if (expAtual >= expMax)
        {
            UparLvl();
        }

	}

   public void UparLvl()
    {

        audioSource.PlayOneShot(lvlupClip);
        StartCoroutine("LvlParticle");
        StartCoroutine("LvlAnim");

        

        experiencePoints++;
        expIndex++;
        MultiplicarExp();
        expAtual = 0;

    }

    void MultiplicarExp()
    {
        expMax = expMax * expMultiplier;
        expToNextLevel = expMax - expAtual;
    }

    public void UpdateBonus()
    {           
            damageBonus = damagePoints * damageMultiplier;
            speedBonus = 0.5f + (speedPoints * speedMultiplier);
            lifeBonus = 1 + (lifePoints * lifeMultiplier);
        

    }

    IEnumerator LvlParticle()
    {
        lvlParticle.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        lvlParticle.SetActive(false);
    }
    IEnumerator LvlAnim()
    {
        
        lvlAnim.SetActive(true);
        yield return new WaitForSeconds(1f);
        lvlAnim.SetActive(false);
    }


}
