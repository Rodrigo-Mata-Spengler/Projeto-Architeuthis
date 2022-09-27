using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Life;

    public float maxLife;

    private void Start()
    {
        Life = maxLife;
    }


    void Update()
    {
        if(Life <= 0)
        {
            NPCReset();
        }
    }

    public void DamageHealth(float damage)
    {
        Life -= damage;


    }
    public void GiveHealth(float cure)
    {
        Life += cure;
    }

    public void NPCReset()
    {
        transform.gameObject.GetComponent<SleepAndReset>().BackToCloset();
        Life = maxLife;
    }

}
