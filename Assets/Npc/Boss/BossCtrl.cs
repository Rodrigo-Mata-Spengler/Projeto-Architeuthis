using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCtrl : MonoBehaviour
{
    private enum Behavior {Follow,Atack,Dash,Defend};

    [SerializeField] private Behavior bossMode;

    public NavMeshAgent boss;

    public Transform alvo;

    public bool teste;

    [SerializeField] private float distanciaDeAtaque;

    [Header("Dash")]
    [SerializeField] private float dashForce;
    [SerializeField] private float dashTime;

    private void Start()
    {
        boss = gameObject.GetComponent<NavMeshAgent>();

        //bossMode = Behavior.Follow;
    }

    private void Update()
    {
        //DesisionMaker();

        switch (bossMode)
        {
            case Behavior.Follow:
                FollowPlayer();
                break;
            case Behavior.Atack:
                break;
            case Behavior.Dash:
                Dash();
                break;
            case Behavior.Defend:
                break;
            default:
                break;
        }
    }

    private void DesisionMaker()
    {
        if (Vector3.Distance(transform.position,alvo.position) > distanciaDeAtaque)
        {
            bossMode = Behavior.Follow;
        }
        else
        {
            bossMode = Behavior.Dash;
        }
    }

    private void FollowPlayer()
    {
        boss.SetDestination(alvo.position);
    }

    private void Dash()
    {

        boss.ResetPath();
        /*float direc = Random.Range(-2, 2);

        gameObject.GetComponent<Rigidbody>().AddForce(dashForce * Time.deltaTime * (2 * transform.right));
        */

        StartCoroutine(DashTimer());
        
        
    }

    IEnumerator DashTimer()
    {
        float starttime = Time.time;

        while (Time.time < starttime + dashTime)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(dashForce * Time.deltaTime * (1 * transform.right));
            yield return null;
        }

        bossMode = Behavior.Follow;
        yield break;
    }
}
