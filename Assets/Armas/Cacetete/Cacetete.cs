using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private float dano;

    [SerializeField] private GameObject escudo;
    private void Start()
    {
        escudo.SetActive(false);
        pupet.ResetTrigger("Marretar");
        pupet.ResetTrigger("Fire2");
        pupet.ResetTrigger("soltar");
    }

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            pupet.SetTrigger("Marretar");
        }
        else
        {
            if (Input.GetButtonDown("Fire2"))
            {
                pupet.SetTrigger("Defender");
                escudo.SetActive(true);
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                pupet.SetTrigger("soltar");
                escudo.SetActive(false);
            }
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && Input.GetButton("Fire1"))
        {
            Health vida = collision.transform.GetComponent<Health>();
            vida.DamageHealth(dano);
        }
    }
}
