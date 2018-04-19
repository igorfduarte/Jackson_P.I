using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeWeapon : MonoBehaviour
{
    HudWeapon hudWeapon;
    GameObject weapon;





   // public List<GameObject> WeaponsPrefab;

    public bool hasAk = false;
    public bool hasVector = false;
    public bool hasShotgun = false;
    public bool hasRaygun = false;
    public bool hasPistol = true;
    public float damageControl;

   public List<GameObject> armas = new List<GameObject>();

    // Use this for initialization
    void Start()
    {

    }
    /*
    public void AddArma(int weaponId)
    {
        if (!armas.Contains(WeaponsPrefab[weaponId]))
        {
            armas.Add(WeaponsPrefab[weaponId]);
        }
    }
    */
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            for (int i = 0; i < armas.Count; i++)
            {
                if (armas[i].activeInHierarchy)
                {
                    armas[i].SetActive(false);
                    if (i == armas.Count - 1)
                    {
                        armas[0].SetActive(true);
                    }
                    else
                    {
                        armas[i + 1].SetActive(true);
                    }

                    break;
                }
            }
        }








        

    }
}
