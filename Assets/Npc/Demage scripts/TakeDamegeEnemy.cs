using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamegeEnemy : MonoBehaviour
{
    private EnemyHealth vida;
    private BTEnemyV01 atirador;
    private BTEnemyCAceteteV01 atacante;
    [SerializeField] private float damage;
    [SerializeField] private bool isBoss;

    [Header("Sound")]
    [SerializeField] private AudioClip dano;
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip defesa;

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
            }
            
            if (atacante)
            {
                if (arma.defender)
                {
                    arma.Dano();
                }
                else
                {
                    arma.DanoAleatorio();
                    vida.DamageHealth(damage);
                }
                atacante.SeePlayer = true;
            }

            if (isBoss)
            {
                if (arma.defender)
                {
                    source.PlayOneShot(defesa);
                    arma.Dano();
                }
                else
                {
                    source.PlayOneShot(dano);
                    arma.DanoAleatorio();
                    vida.DamageHealth(damage);
                }
            }
            
        }
    }
    
}
