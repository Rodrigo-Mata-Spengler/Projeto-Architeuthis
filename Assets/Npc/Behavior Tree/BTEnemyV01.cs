using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTEnemyV01 : MonoBehaviour
{
    [HideInInspector]
    public float Yrotation;

    public GameObject rifle;

    public bool InPlace;

    public bool SeePlayer;

    [HideInInspector]public NavMeshAgent agent;

    public float distToPlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        SeePlayer = GetComponent<FieldOfView>().SeePlayer;

        BTSelector ammo = new BTSelector();

        ammo.children.Add(new BTVerificarBalas());
        ammo.children.Add(new BTRecarregar());

        BTSequance arma = new BTSequance();

        arma.children.Add(ammo);
        arma.children.Add(new BTAtirar());

        BTSequance Enemy = new BTSequance();

        Enemy.children.Add(new BTFindPlayer());
        Enemy.children.Add(new BTMoverParaPlayer());
        Enemy.children.Add(arma);

        BehaviorTree bt = GetComponent<BehaviorTree>();
        bt.root = Enemy;

        StartCoroutine(bt.Execute());
    }

    public void Sleep()
    {
        StopAllCoroutines();
    }
    public void UpdateDestination(GameObject target, GameObject[] waypoints, int waypointsIndex, NavMeshAgent agent)
    {
        target = waypoints[waypointsIndex];
        agent.SetDestination(target.transform.position);
    }
    public void IterateWaypoints(int waypointsIndex, GameObject[]waypoints)
    {
        waypointsIndex++;
        if(waypointsIndex == waypoints.Length)
        {
            waypointsIndex = 0;
        }
    }
}
