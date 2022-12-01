using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamageFromRaycast : MonoBehaviour
{
    private EnemyHealth vida;
    private BTEnemyV01 atirador;
    private BTEnemyCAceteteV01 atacante;



    public float addDamage;
    private void Start()
    {
        vida = gameObject.GetComponent<EnemyHealfhRef>().vida;

    }

    public void DoDamage(float damage)
    {
        vida.DamageHealth(damage * addDamage);
    }

}
