using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamegeEnemy : MonoBehaviour
{
    private EnemyHealth vida;
    private BTEnemyV01 atirador;
    private BTEnemyCAceteteV01 atacante;
    [SerializeField] private float damage;

    public Cacetete2 arma;
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
            if (atirador)
            {
                vida.DamageHealth(damage);
                atirador.SeePlayer = true;
                Destroy(other);
            }
            
            if (atacante)
            {
                if (arma.defender)
                {
                    arma.Dano();
                }
                else
                {
                    vida.DamageHealth(damage);

                    arma.DanoAleatorio();
                }
                atacante.SeePlayer = true;
            }
            
        }
    }
}
