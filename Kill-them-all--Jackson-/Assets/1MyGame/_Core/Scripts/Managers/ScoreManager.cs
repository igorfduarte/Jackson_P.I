using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    

    Text text;
    Tiro tiro;
    GameObject jogador;
    GameObject player;
    Shop shop;
    GameObject shopObject;
    //public string pistolText;
    Weapon weapon;
    [SerializeField] bool isPotion;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        text = GetComponent <Text> ();
        score = 0;
        tiro = player.GetComponent<Tiro>();

    }


    void Update ()
    {
        if (isPotion)
        {
            if (tiro.molotovActive)
            {
                score = shop.molotovCount;
                text.text = "" + score;
            }

            if (tiro.icePotionActive)
            {
                score = shop.iceCount;
                text.text = "" + score;
            }
        }
       
       
        else
        {

            jogador = GameObject.FindGameObjectWithTag("Weapon");
            weapon = jogador.GetComponent<Weapon>();

            UpdateAmmoHUD();
        }


    }

    public void UpdateAmmoHUD()
    {
        if (weapon.maxAmmo >= 100000)
        {
            score = weapon.currentAmmo;
            text.text = " " + score + "/Infinito";
        }
        else
        {
            score = weapon.currentAmmo;
            text.text = " " + score + "/" + weapon.maxAmmo;
        }
    }
}
