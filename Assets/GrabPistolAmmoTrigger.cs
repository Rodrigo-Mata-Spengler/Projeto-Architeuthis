using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabPistolAmmoTrigger : MonoBehaviour
{

    public GivePistolAmmo GivePistolAmmoObj;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivePistolAmmoObj.enabled = true;
            //GivePistolAmmo.enabled = true;
            //GiveAmmoRifleObj.enabled = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivePistolAmmoObj.enabled = false;

        }
    }

}
