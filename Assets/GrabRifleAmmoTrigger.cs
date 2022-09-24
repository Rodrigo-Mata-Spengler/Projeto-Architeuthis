using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabRifleAmmoTrigger : MonoBehaviour
{
    public GiveAmmoRifle GiveAmmoRifleObj;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveAmmoRifleObj.enabled = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveAmmoRifleObj.enabled = false;

        }
    }
}
