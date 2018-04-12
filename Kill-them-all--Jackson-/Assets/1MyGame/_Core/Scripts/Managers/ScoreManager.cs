using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Player player;

    Text text;
    GameObject jogador;
    //public string pistolText;
    Weapon weapon;


    void Awake ()
    {

        text = GetComponent <Text> ();
        score = 0;
        
    }


    void Update ()
    {
        jogador = GameObject.FindGameObjectWithTag("Weapon");
        weapon = jogador.GetComponent<Weapon>();

        UpdateAmmoHUD();

    }

    public void UpdateAmmoHUD()
    {
        if (weapon.maxAmmo >= 100000)
        {
            score = weapon.currentAmmo;
            text.text = "Ammo: " + score + "/Infinito";
        }
        else
        {
            score = weapon.currentAmmo;
            text.text = "Ammo: " + score + "/" + weapon.maxAmmo;
        }
    }
}
