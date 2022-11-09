using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyInPlace : MonoBehaviour
{
    [SerializeField]GameObject ExitTrigger;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<BTEnemyV01>().InPlace = true;
            other.GetComponent<BTEnemyV01>().Yrotation = gameObject.transform.eulerAngles.y;

            ExitTrigger.SetActive(true);
            gameObject.SetActive(false);
        }
    }

}
