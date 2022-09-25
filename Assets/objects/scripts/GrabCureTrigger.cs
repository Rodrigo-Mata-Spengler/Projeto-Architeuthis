using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabCureTrigger : MonoBehaviour
{
    [SerializeField] private Text IsFull;
    [SerializeField] private Text PressF;

    public CureObject CureObject;
    //public GiveAmmoRifle GiveAmmoRifleObj;
    //public GivePistolAmmo GivePistolAmmo;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CureObject.enabled = true;

            CureObject.ActiveText = true;
            //GivePistolAmmo.enabled = true;
            //GiveAmmoRifleObj.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PressF.enabled = false;
            IsFull.enabled = false;
            CureObject.ActiveText = false;

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

