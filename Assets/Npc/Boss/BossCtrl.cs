using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossCtrl : MonoBehaviour
{
    public NavMeshAgent boss;

    public Transform alvo;

    public bool teste;

    private void Start()
    {
        boss = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!alvo)
        {
            boss.SetDestination(alvo.position);
        }
        
    }
}
