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
            UnityEngine.Debug.Log("entrou");
            other.GetComponent<BTEnemyV01>().InPlace = true;
            filho.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            
            other.GetComponent<BTEnemyV01>().InPlace = false;
            filho.SetActive(true);
        }
    }
}
