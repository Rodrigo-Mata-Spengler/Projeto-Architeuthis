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

    [HideInInspector]
    public float dist;

    public float distToObj;

    public int AmmoGiveAmount;

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);


        if (dist < distToObj && PressText.enabled == false)
        {
            PressText.enabled = true;
        }
        else if(PressText.enabled == true)
        {
            PressText.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj)
        {
            Rifle.GetComponent<AmmoRifle>().GiveAmmo(AmmoGiveAmount);

            Destroy(Pai, 0.1f);
            PressText.enabled = false;

        }
    }
}
