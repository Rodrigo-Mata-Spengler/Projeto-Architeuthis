using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private float dano;

    private void Start()
    {
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

        if (Input.GetButtonDown("Fire2"))
        {
            pupet.SetTrigger("Defender");
        }else if (Input.GetButtonUp("Fire2"))
        {
            pupet.SetTrigger("soltar");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health vida = collision.transform.GetComponent<Health>();
            vida.DamageHealth(dano);
        }
    }
}
