using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Life;
 

    void Update()
    {
        
    }

    public void DamageHealth(float damage)
    {
        Life -= damage;

       
    }
    public void GiveHealth(float cure)
    {
        Life += cure;
    }


}
