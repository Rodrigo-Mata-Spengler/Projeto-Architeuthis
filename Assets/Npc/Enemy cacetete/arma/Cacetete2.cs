using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete2 : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] private bool escudo;
    private void Start()
    {
        escudo = false;
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
        escudo = true;
    }

    public void Soltar()
    {
        pupet.SetTrigger("Defender 2");
        escudo = false;
    }
}
