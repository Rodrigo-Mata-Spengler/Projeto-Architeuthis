using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyInPlace : MonoBehaviour
{
    [SerializeField]GameObject filho;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {           
            filho.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            filho.SetActive(true);
        }
    }
}
