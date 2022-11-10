using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamegeEnemy : MonoBehaviour
{
    private EnemyHealth vida;
    private BTEnemyV01 atirador;
    private BTEnemyCAceteteV01 atacante;
    [SerializeField] private float damage;
    private void Start()
    {
        vida = gameObject.GetComponent<EnemyHealfhRef>().vida;
        atirador = gameObject.GetComponent<EnemyHealfhRef>().atirador;
        atacante = gameObject.GetComponent<EnemyHealfhRef>().atacante;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            vida.DamageHealth(damage);
            if (atirador)
            {
                Debug.Log("dano");
                atirador.SeePlayer = true;
            }
            
            if (atacante)
            {
                atacante.SeePlayer = true;
            }
            Destroy(other);
        }
    }
}
