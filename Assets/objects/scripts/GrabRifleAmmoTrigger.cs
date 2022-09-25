using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabRifleAmmoTrigger : MonoBehaviour
{
    [SerializeField] private Text IsFull;
    [SerializeField] private Text PressF;

    public GiveAmmoRifle GiveAmmoRifleObj;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveAmmoRifleObj.enabled = true;
            GiveAmmoRifleObj.ActiveText = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PressF.enabled = false;
            IsFull.enabled = false;
            GiveAmmoRifleObj.ActiveText = false;

            GiveAmmoRifleObj.enabled = false;

        }
    }
}
