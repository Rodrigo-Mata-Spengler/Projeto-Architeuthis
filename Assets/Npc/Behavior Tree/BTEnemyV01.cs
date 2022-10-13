using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTEnemyV01 : MonoBehaviour
{
    
    public float Yrotation;

    public GameObject rifle;

    public bool InPlace;

    [HideInInspector]public NavMeshAgent agent;

    public float distToPlayer;


    //Field of view
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask PlayerMask;
    public LayerMask AmbienteMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    //[HideInInspector]
    public bool SeePlayer;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FindTargetsWithDelay(.2f));

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
    public void MoveToTarget(GameObject target, NavMeshAgent agent)
    {
        agent.SetDestination(target.transform.position);
    }
    public void IterateWaypoints(int waypointsIndex, GameObject[]waypoints)
    {

        if (waypointsIndex == waypoints.Length)
        {
            waypointsIndex = 0;
        }
        waypointsIndex += 1;
        Debug.LogWarning(waypointsIndex);


    }
    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTrgets();
        }
    }
    void FindVisibleTrgets()
    {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, PlayerMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float dstToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, dstToTarget, AmbienteMask))
                {

                    visibleTargets.Add(target);
                    SeePlayer = true;
                    Debug.LogWarning("vi");
                }
                else
                {
                    SeePlayer = false;
                }

            }
        }
    }

    public Vector3 DirFromAngle(float AngleInDegrees, bool AngleIsGlobal)
    {
        if (!AngleIsGlobal)
        {
            AngleInDegrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(AngleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(AngleInDegrees * Mathf.Deg2Rad));
    }
}


