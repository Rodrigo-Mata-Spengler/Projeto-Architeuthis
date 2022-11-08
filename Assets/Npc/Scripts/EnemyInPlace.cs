using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyInPlace : MonoBehaviour
{
    [SerializeField]GameObject ExitTrigger;

    private void OnTriggerEnter(Collider other)
    {
        UnityEngine.Debug.LogError(" Não entrou");

        if (other.gameObject.CompareTag("Enemy"))
        {
            UnityEngine.Debug.LogError("entrou");
            other.GetComponent<BTEnemyV01>().InPlace = true;
            other.GetComponent<BTEnemyV01>().Yrotation = gameObject.transform.eulerAngles.y;

            ExitTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
