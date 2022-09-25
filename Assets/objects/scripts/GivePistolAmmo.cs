using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePistolAmmo : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject Player;
    public GameObject Pai;

    public Text PressText;
    public Text IsFullText;

    private int MaxBagSee;


    public int AmmoGiveAmount;

    [SerializeField] public bool ActiveText = false;

    void Awake()
    {
        
        //MaxBagSee = Pistol.GetComponent<Ammo>().MaxBag;

    }

    // Update is called once per frame
    void Update()
    {
        if (Pistol.GetComponent<Ammo>().MaxBag >= 60)
        {
            IsFullText.enabled = true;
        }
        else
        {
            PressText.enabled = true;


            if (Input.GetKeyDown(KeyCode.F) && Pistol.GetComponent<Ammo>().MaxBag < 60)
            {
                Pistol.GetComponent<Ammo>().GiveAmmo(AmmoGiveAmount);

                GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = false;

                Destroy(Pai, 0.1f);

                PressText.enabled = false;
                IsFullText.enabled = false;

            }
        }
    }
}
