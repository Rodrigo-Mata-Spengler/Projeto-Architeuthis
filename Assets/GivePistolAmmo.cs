using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GivePistolAmmo : MonoBehaviour
{
    public GameObject Pistol;
    public GameObject Player;

    public Text PressText;

    [HideInInspector]
    public float dist;

    public float distToObj;

    public int AmmoGiveAmount;

    private string GrabObj = "Press [F] to grab";

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);

        Debug.Log(dist);

        if (dist < distToObj)
        {
            PressText.text = GrabObj;
        }
        else
        {
            PressText.text = "";
        }


        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj)
        {
            Pistol.GetComponent<Ammo>().GiveAmmo(AmmoGiveAmount);

            Destroy(gameObject, 0.1f);

        }
    }
}
