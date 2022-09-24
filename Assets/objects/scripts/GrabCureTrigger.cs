using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabCureTrigger : MonoBehaviour
{

    public CureObject CureObject;
    //public GiveAmmoRifle GiveAmmoRifleObj;
    //public GivePistolAmmo GivePistolAmmo;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CureObject.enabled = true;
            //GivePistolAmmo.enabled = true;
            //GiveAmmoRifleObj.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CureObject.enabled = false;

        }
    }
    /*private void OnCollider(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CureObject.enabled = true;
            GivePistolAmmo.enabled = true;
            GiveAmmoRifleObj.enabled = true;
        }
    }*/



}

