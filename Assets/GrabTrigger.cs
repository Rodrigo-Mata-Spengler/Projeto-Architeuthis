using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTrigger : MonoBehaviour
{
    public CureObject CureObject;
    public GiveAmmoRifle GiveAmmoRifleObj;
    public GivePistolAmmo GivePistolAmmo;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            CureObject.enabled = true;
            GivePistolAmmo.enabled = true;
            GiveAmmoRifleObj.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CureObject.enabled = false;
            GivePistolAmmo.enabled = false;
            GiveAmmoRifleObj.enabled = false;
        }
    }

}
