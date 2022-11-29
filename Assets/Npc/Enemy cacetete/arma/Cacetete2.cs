using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete2 : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    [SerializeField] public bool defender;

    [SerializeField] private bool isBoss;

    [SerializeField] private AudioClip audio;
    [SerializeField] private AudioSource audioS;
    private void Start()
    {
        defender = false;
        pupet.ResetTrigger("Atacar");
    }

    public void Atacar()
    {
        pupet.SetTrigger("Atacar");
        if (!audioS.isPlaying)
        {
            audioS.PlayOneShot(audio);
        }
        
    }

    public void Defender()
    {
        pupet.SetBool("Defender",true);
        defender = true;
    }

    public void Soltar()
    {
        pupet.SetBool("Defender", false);
        defender = false;
    }

    public void Dano()
    {
        pupet.SetTrigger("Defendeu");
    }

    public void DanoAleatorio()
    {
        if (isBoss)
        {
            pupet.SetTrigger("Dano");
        }else
        {
            int a = Random.Range(1, 3);

            if (a == 1)
            {
                pupet.SetInteger("Dano", 1);
            }
            else
            {
                pupet.SetInteger("Dano", 2);
            }

            pupet.SetInteger("Dano", 0);
        }
        
    }
}
