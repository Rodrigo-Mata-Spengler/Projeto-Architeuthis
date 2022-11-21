using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete2 : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private float dano;

    [SerializeField] private GameObject escudo;
    private void Start()
    {
        escudo.SetActive(false);
        pupet.ResetTrigger("Atacar");
        pupet.ResetTrigger("Defender");
        pupet.ResetTrigger("Defender 2");
    }

    public void Atacar()
    {
        pupet.SetTrigger("Atacar");
    }

    public void Defender()
    {
        pupet.SetTrigger("Defender");
        escudo.SetActive(true);
    }

    public void Soltar()
    {
        pupet.SetTrigger("Defender 2");
        escudo.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Health vida = collision.transform.GetComponent<Health>();
            vida.DamageHealth(dano);
        }
    }
}
