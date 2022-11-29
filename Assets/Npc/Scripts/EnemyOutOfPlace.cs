using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOutOfPlace : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject EnterTrigger;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {

            other.GetComponent<BTEnemyV01>().InPlace = false;
            EnterTrigger.SetActive(true);
            gameObject.SetActive(false);    
        }
        else
        {

        }
    }
}
