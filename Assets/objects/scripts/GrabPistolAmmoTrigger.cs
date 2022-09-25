using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class GrabPistolAmmoTrigger : MonoBehaviour
{
    public GivePistolAmmo GivePistolAmmoObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GivePistolAmmoObj.enabled = true;

            GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = true;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = false;

            GivePistolAmmoObj.enabled = false;
        }
    }

}
