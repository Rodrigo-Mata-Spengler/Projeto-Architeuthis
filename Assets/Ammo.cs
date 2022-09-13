using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{


    public int ammo;
    public Text AmmoText;

    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variavél para o texto na tela


        if (Input.GetButtonDown("Fire1") && ammo > 0) //atira
        {
            ammo--;
        }

    }
}
