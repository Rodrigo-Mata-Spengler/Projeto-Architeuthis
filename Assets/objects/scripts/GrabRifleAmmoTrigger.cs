using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabRifleAmmoTrigger : MonoBehaviour
{


    public GiveAmmoRifle GiveAmmoRifleObj;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GiveAmmoRifleObj.enabled = true;

            GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = false;

            GiveAmmoRifleObj.enabled = false;

        }
    }
}
