using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCtrl : MonoBehaviour
{
    private enum Behavior {Follow,Atack,Dash,Defend,Special,Idle};

    [SerializeField] private Behavior bossMode;

    private NavMeshAgent boss;

    public Transform alvo;

    [SerializeField] private int probabilidade = 0;

    [SerializeField] private CharacterController controller;

    [SerializeField] private float distanciaDeAtaque;

    [Header("Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashProvabilidade;

    [Header("Atacar")]
    [SerializeField] private Cacetete2 cacetete;
    [SerializeField] private float ataqueProvabilidade;

    [Header("Defender")]
    [SerializeField] private float defenderTimer = 0;
    [SerializeField] private float defesaProvabilidade;

    [Header("Especial")]
    [SerializeField] private float forçaPraTraz;
    [SerializeField] private float trazTime;
    [SerializeField] private float tempoEsperaAtaque;
    [SerializeField] private float ataqueTime;
    [SerializeField] private float forcaAtaque;
    [SerializeField] private float specialProvabilidade;

    private bool inUse = false;

    [Header("Animation")]
    [SerializeField] private Animator anim;


    private void Start()
    {
        boss = gameObject.GetComponent<NavMeshAgent>();

        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        DesisionMaker();

        switch (bossMode)
        {
            case Behavior.Follow:
                FollowPlayer();
                break;
            case Behavior.Atack:
                Atacar();
                break;
            case Behavior.Dash:
                Dash();
                break;
            case Behavior.Defend:
                Defender();
                break;
            case Behavior.Special:
                Special();
                break;
            case Behavior.Idle:
                Idle();
                break;
            default:
                break;
        }
    }

    private void DesisionMaker()
    {
        if (!inUse)
        {
            if (Vector3.Distance(transform.position, alvo.position) >= distanciaDeAtaque)
            {
                bossMode = Behavior.Follow;
            }
            else
            {
                probabilidade = Random.Range(0, 100);

                if (probabilidade <= ataqueProvabilidade)
                {
                    bossMode = Behavior.Atack;

                }
                else if (probabilidade <= defesaProvabilidade)
                {
                    bossMode = Behavior.Defend;
                }
                else if (probabilidade <= specialProvabilidade)
                {
                    bossMode = Behavior.Special;
                }
                else if (probabilidade <= dashProvabilidade)
                {
                    bossMode = Behavior.Dash;
                }
                else
                {
                    bossMode = Behavior.Idle;
                }
            }
        }   
    }

    private void FollowPlayer()
    {
        boss.SetDestination(alvo.position);
        anim.SetBool("IsIdle",false);
    }

    private void Dash()
    {
        inUse = true;
        boss.enabled = false;
        //controller.enabled = true;

        int a = 0;

        if(Random.Range(0,100) >= 50)
        {
            a = -1;
        }
        else
        {
            a = 1;
        }

        StartCoroutine(DashTimer(a));     
    }

    IEnumerator DashTimer(int a)
    {
        float starttime = Time.time;

        while (Time.time < starttime + dashTime)
        {
            controller.Move(dashForce * Time.deltaTime * (a * transform.right));
            anim.SetInteger("Dash",a);

            yield return null;
        }

        boss.enabled = true;
        //controller.enabled = false;
        bossMode = Behavior.Idle;
        inUse = false;
        yield break;
    }

    private void Atacar()
    {
        inUse = true;
        cacetete.Atacar();

        bossMode = Behavior.Idle;
        inUse = false;
    }

    private void Defender()
    {
        inUse = true;
        StartCoroutine(DefenderTimer());
    }

    IEnumerator DefenderTimer()
    {
        yield return new WaitForSeconds(.5f);

        cacetete.Defender();

        yield return new WaitForSeconds(defenderTimer);

        cacetete.Soltar();

        bossMode = Behavior.Idle;
        inUse = false;
        yield break;
    }

    private void Special()
    {
        inUse = true;
        //boss.enabled = false;
        boss.isStopped = true;
       // controller.enabled = true;

        StartCoroutine(SpecialMove());
    }

    IEnumerator SpecialMove()
    {
        float starttime = Time.time;

        while (Time.time < starttime + trazTime)
        {
            controller.Move(forçaPraTraz * Time.deltaTime * (-1 * transform.forward));
            anim.SetTrigger("PreparaSpecial");

            yield return null;
        }

        yield return new WaitForSeconds(tempoEsperaAtaque);

        starttime = Time.time;

        while (Time.time < starttime + ataqueTime)
        {
            controller.Move(forcaAtaque * Time.deltaTime * (1 * transform.forward));
            anim.SetTrigger("Special");

            yield return null;
        }

        //boss.enabled = true;
        boss.isStopped = false;
        //controller.enabled = false;
        bossMode = Behavior.Idle;
        inUse = false;
        yield break;
    }

    private void Idle()
    {
        anim.SetBool("IsIdle", true);
    }
}
