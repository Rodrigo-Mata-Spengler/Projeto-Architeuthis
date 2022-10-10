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

        BTSequance SequenceA = new BTSequance();

        SequenceA.children.Add(new BTPlayerCloseOrInPointOfView());
        SequenceA.children.Add(new BTMoverParaPlayer());

        BTSequance SequenceB = new BTSequance();

        SequenceB.children.Add(new BTPlaceAvailable());
        SequenceB.children.Add(new BTGoToPlace());
        SequenceB.children.Add(new BTInPlace());
        SequenceB.children.Add(new BTSearchPlayer());
        SequenceB.children.Add(new BTPlayerCloseOrInPointOfView());

        BTSequance SequenceC = new BTSequance();

        SequenceC.children.Add(new BTPlaceNotAvailable());
        SequenceC.children.Add(new BTPlayerNotCloseOrInPointOfView());
        SequenceC.children.Add(new BTPatrol());

        BTSelector SelectorA = new BTSelector();

        SelectorA.children.Add(SequenceA);
        SelectorA.children.Add(SequenceB);
        SelectorA.children.Add(SequenceC);

        BTSelector SelectorB = new BTSelector();

        SelectorB.children.Add(new BTHaveAmmo());
        SelectorB.children.Add(new BTReload());

        BTSequance SequenceD = new BTSequance();

        SequenceD.children.Add(SelectorA);
        SequenceD.children.Add(SelectorB);
        SequenceD.children.Add(new BTAtirar());

        BehaviorTree bt = GetComponent<BehaviorTree>();
        bt.root = SequenceD;

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
    public void MoveToPlayer(GameObject target, NavMeshAgent agent)
    {
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
