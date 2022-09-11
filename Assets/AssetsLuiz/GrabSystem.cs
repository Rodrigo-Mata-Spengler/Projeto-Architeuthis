using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GrabSystem : MonoBehaviour
{
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
        if (Input.GetKeyDown(KeyCode.F) && dist < distToObj && gameObject.CompareTag("Ammo"))
        {
            GiveAmmo();
            Destroy(gameObject);

        }
    }
    public void GiveAmmo()
    {
        if(Player.GetComponent<HealthAmmo>().ammo + AmmoGive > 100)
        {
            Player.GetComponent<HealthAmmo>().ammo = 100;
        }
        else
        {
            Player.GetComponent<HealthAmmo>().ammo += AmmoGive; ;
        }
        
        
    }

    public void GiveLive()
    {
        if (Player.GetComponent<HealthAmmo>().Life + LifeGive > 100)
        {
            Player.GetComponent<HealthAmmo>().Life = 100;
        }
        else
        {
            Player.GetComponent<HealthAmmo>().Life += LifeGive;
        }
        
        
    }
    
}
