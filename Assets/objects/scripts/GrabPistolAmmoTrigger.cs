using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabPistolAmmoTrigger : MonoBehaviour
{
    [SerializeField] private Text IsFull;
    [SerializeField] private Text PressF;

    public GivePistolAmmo GivePistolAmmoObj;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivePistolAmmoObj.enabled = true;
            GivePistolAmmoObj.ActiveText = true;
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
            GivePistolAmmoObj.ActiveText = false;

            GivePistolAmmoObj.enabled = false;
        }
    }

}
