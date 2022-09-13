using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{

    public int ammo;
    public Text AmmoText;



    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString();

        if (Input.GetButtonDown("Fire1") && ammo > 0) //atira
        {
            ammo--;
        }
    }
}
