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

    private int MaxBag;

    /*
    [HideInInspector]
    public float dist;

    public float distToObj;*/

    public int AmmoGiveAmount;

    [SerializeField] public bool ActiveText = false;

    // Start is called before the first frame update
    void Start()
    {
        
        MaxBag = Rifle.GetComponent<Ammo>().MaxBag;

    }

    // Update is called once per frame
    void Update()
    {
        if (ActiveText == true)
        {
            if (MaxBag >= Player.GetComponent<Health>().MaxLife)
            {
                IsFullText.enabled = true;
            }
            else
            {
                PressText.enabled = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && Rifle.GetComponent<Ammo>().MaxBag < MaxBag)
        {
            Rifle.GetComponent<Ammo>().GiveAmmo(AmmoGiveAmount);

            Destroy(Pai, 0.1f);
            PressText.enabled = false;

        }
    }
}
