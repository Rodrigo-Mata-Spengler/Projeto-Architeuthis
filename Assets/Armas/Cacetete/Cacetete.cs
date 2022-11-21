using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private float dano;

    [SerializeField] private GameObject escudo;

    private bool batendo = false;
    private bool defendendo = false;
    private void Start()
    {
        escudo.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            batendo = true;
            pupet.SetBool("Marretar", true);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            batendo = false;
            pupet.SetBool("Marretar", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {

            escudo.SetActive(true);
            defendendo = true;
            pupet.SetBool("Defender", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {

            escudo.SetActive(false);
            defendendo = false;
            pupet.SetBool("Defender", false);
        }
    }
}
