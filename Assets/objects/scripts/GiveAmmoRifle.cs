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

    /*
    [HideInInspector]
    public float dist;

    public float distToObj;*/

    public int AmmoGiveAmount;

 
    // Start is called before the first frame update
    void Start()
    {
        PressText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.F))
        {
            Rifle.GetComponent<Ammo>().GiveAmmo(AmmoGiveAmount);

            Destroy(Pai, 0.1f);
            PressText.enabled = false;

        }
    }
}
