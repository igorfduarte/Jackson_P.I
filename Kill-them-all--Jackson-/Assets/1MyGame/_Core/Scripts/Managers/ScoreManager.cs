using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public static int score;
    Player player;

    Text text;
    GameObject jogador;
    Shop shop;
    GameObject shopObject;
    //public string pistolText;
    Weapon weapon;
    [SerializeField] bool IcePotionCount;


    void Awake ()
    {
        shopObject = GameObject.FindGameObjectWithTag("Shop");
        shop = shopObject.GetComponent<Shop>();
        text = GetComponent <Text> ();
        score = 0;
        
    }


    void Update ()
    {
        if (IcePotionCount )
        {
            score = shop.iceCount;
            text.text = "" + score;
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
            text.text = "Ammo: " + score + "/Infinito";
        }
        else
        {
            score = weapon.currentAmmo;
            text.text = "Ammo: " + score + "/" + weapon.maxAmmo;
        }
    }
}
