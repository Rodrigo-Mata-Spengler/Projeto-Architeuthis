using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private float dano;

    private bool batendo = false;
    private bool defendendo = false;
    [SerializeField]private AudioClip audio;
    [SerializeField] private AudioSource audioS;

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            batendo = true;
            pupet.SetBool("Marretar", true);
            //audioS.PlayOneShot(audio);
        }
        if(Input.GetButtonUp("Fire1"))
        {
            batendo = false;
            pupet.SetBool("Marretar", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            defendendo = true;
            pupet.SetBool("Defender", true);
        }
        if (Input.GetButtonUp("Fire2"))
        {
            defendendo = false;
            pupet.SetBool("Defender", false);
        }
    }
}
