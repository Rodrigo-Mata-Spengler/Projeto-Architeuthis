using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoRifle : MonoBehaviour
{

    public int Maxammo;
    [HideInInspector]
    public int ammo;

    public int MaxBag;
    public Text AmmoText;
    public Text AmmoBagText;

    private void Start()
    {
        ammo = Maxammo;
    }
    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variavél para o texto na tela
        AmmoBagText.text = MaxBag.ToString();

        if (Input.GetKeyDown(KeyCode.R) && MaxBag > 0)
        {

            if (MaxBag <= 30)
            {
                int subB = (ammo - MaxBag) * -1;
                ammo += subB;
                MaxBag -= subB;
            }
            if ((MaxBag + ammo) < 30)
            {
                ammo = MaxBag + ammo;

                MaxBag -= MaxBag;
            }
            else
            {
                int sub = ammo - Maxammo;
                sub = sub * -1;
                ammo += sub;
                MaxBag -= sub;
            }

        }

        if (Input.GetButtonDown("Fire1") && ammo > 0) //atira
        {
            ammo--;
        }
    }
}
