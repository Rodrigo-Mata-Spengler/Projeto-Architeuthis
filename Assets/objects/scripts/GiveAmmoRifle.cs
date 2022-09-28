using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiveAmmoRifle : MonoBehaviour
{
    public GameObject Rifle;
    public GameObject Player;
    public GameObject Pai;

    public Text PressText;

    public Text IsFullText;

    private int MaxBagSee;


    public int AmmoGiveAmount;

    [SerializeField] public bool ActiveText = false;

 
    void Awake()
    {
        PressText = GameObject.FindGameObjectWithTag("PressF").GetComponent<Text>();
        IsFullText = GameObject.FindGameObjectWithTag("IsFull").GetComponent<Text>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Rifle = GameObject.FindGameObjectWithTag("PlaRifle");
        //MaxBagSee = Rifle.GetComponent<Ammo>().MaxBag;

    }

 
    void Update()
    {
        

        if ( Rifle.GetComponent<Ammo>().MaxBag >= 90)
        {
            IsFullText.enabled = true;
        }
        else
        {
            PressText.enabled = true;

            if (Input.GetKeyDown(KeyCode.F) && Rifle.GetComponent<Ammo>().MaxBag < 90)
            {
                Rifle.GetComponent<Ammo>().GiveAmmo(AmmoGiveAmount);

                GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = false;

                Destroy(Pai, 0.1f);
                PressText.enabled = false;
                IsFullText.enabled = false;

            }
        }

    }
}
