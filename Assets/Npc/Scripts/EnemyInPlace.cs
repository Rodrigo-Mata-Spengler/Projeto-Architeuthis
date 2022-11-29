using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class EnemyInPlace : MonoBehaviour
{
    [SerializeField]GameObject ExitTrigger;
    [SerializeField] GameObject PrefabPlace;

    //[SerializeField] Collider TriggerCollider;

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<BTEnemyV01>().InPlace = true;
            other.GetComponent<BTEnemyV01>().Yrotation = PrefabPlace.transform.eulerAngles.y;

            ExitTrigger.SetActive(false);

            /*
            ExitTrigger.SetActive(true);
            gameObject.SetActive(false);
            */
        }
        else
        {
            ExitTrigger.SetActive(true);
        }
    }

}
