using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrabSystem : MonoBehaviour
{
    //o script vai no objeto que irá ser pego
    public GameObject Player;

    public Text PressText;

    [HideInInspector]
    public float dist;

    public float distToObj;

    public int AmmoGive;
    public float LifeGive;


    private void Update()
    {
        pickUpResources();
    }


    public void pickUpResources()
    {
        dist = Vector3.Distance(Player.transform.position, transform.position);

        Debug.Log(dist);

        //Checa se o player está perto do objeto e qual o tipo do objeto
        if (dist < distToObj)
        {
            PressText.enabled = true;
        }
        else
        {
            PressText.enabled = false;
        }

        
        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj && gameObject.CompareTag("Life"))
        {
            GiveLive();
            Destroy(gameObject);

        }

        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj && gameObject.CompareTag("AmmoPistol"))
        {
            GiveAmmo();
            

        }

        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj && gameObject.CompareTag("AmmoRifle"))
        {
            GiveAmmoRifle();
            Destroy(gameObject);

        }
    }


    public void GiveAmmo()
    {
        if (Player.GetComponent<Ammo>().MaxBag + AmmoGive > 90)
        {
            Player.GetComponent<Ammo>().MaxBag = 90;
        }
        else
        {
            Player.GetComponent<Ammo>().MaxBag += AmmoGive; ;
        }
        Destroy(gameObject);


    }

    public void GiveAmmoRifle()
    {
        if (Player.GetComponent<AmmoRifle>().MaxBag + AmmoGive > Player.GetComponent<AmmoRifle>().MaxBag)
        {
            Player.GetComponent<AmmoRifle>().MaxBag = Player.GetComponent<AmmoRifle>().MaxBag;
        }
        else
        {
            Player.GetComponent<AmmoRifle>().MaxBag += AmmoGive; ;
        }


    }

    public void GiveLive()
    {
        if (Player.GetComponent<Health>().Life + LifeGive > 100)
        {
            Player.GetComponent<Health>().Life = 100;
        }
        else
        {
            Player.GetComponent<Health>().Life += LifeGive;
        }
        
        
    }
    
}
