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

    public float FireRate = 15f;
    private float NextTimeToFire = 0f;

    private void Start()
    {
        ammo = Maxammo;

        
    }
    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variavél para o texto na tela
        AmmoBagText.text = MaxBag.ToString();

        if (Input.GetKeyDown(KeyCode.R) && MaxBag >= 0)
        {

            if (MaxBag <= Maxammo)
            {
                int subB = (ammo - MaxBag) * -1;
                ammo += subB;
                MaxBag -= subB;
            }
            if ((MaxBag + ammo) < Maxammo)
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

        if (Input.GetButton("Fire1")&& Time.time>= NextTimeToFire && ammo > 0) //atira
        {
            NextTimeToFire = Time.time + 1f / FireRate;

            ammo--;

            Debug.Log("Shooting");
        }
    }
}
