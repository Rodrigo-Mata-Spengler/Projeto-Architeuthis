using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTEnemyCAceteteV01 : MonoBehaviour
{
    public float Yrotation;

    public Transform area;

    public Cacetete2 Cacetete;

    public bool InPlace;

    [HideInInspector] public NavMeshAgent agent;

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

    [Range(0,100)]public float porcentagemdefender = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        StartCoroutine(FindTargetsWithDelay(0.01f));

        BTSequance SequenceA = new BTSequance();

        SequenceA.children.Add(new BTPlayerCloseOrInPointOfViewv02());
        SequenceA.children.Add(new BTMoverParaPlayerv02());

        BTSequance SequenceB = new BTSequance();

        SequenceB.children.Add(new BTPlayerCloseOrInPointOfViewv02());

        BTSequance SequenceC = new BTSequance();

        SequenceC.children.Add(new BTPlayerNotCloseOrInPointOfViewv02());
        SequenceC.children.Add(new BTPatrolv02());

        BTSelector SelectorA = new BTSelector();

        SelectorA.children.Add(SequenceA);
        SelectorA.children.Add(SequenceB);
        SelectorA.children.Add(SequenceC);

        BTSelector SelectorB = new BTSelector();

        SelectorB.children.Add(new BTBaterDefender());
        SelectorB.children.Add(new BTDefender());

        BTSequance SequenceD = new BTSequance();

        SequenceD.children.Add(SelectorA);
        SequenceD.children.Add(SelectorB);
        SequenceD.children.Add(new BTMira());
        SequenceD.children.Add(new BTBater());

        BehaviorTree bt = GetComponent<BehaviorTree>();
        bt.root = SequenceD;

        StartCoroutine(bt.Execute());
    }



    public void Sleep()
    {
        StopAllCoroutines();
    }
    public void MoveToTarget(GameObject target, NavMeshAgent agent)
    {
        agent.SetDestination(target.transform.position);
    }
    public void MoveAwayFromTarget(GameObject target, NavMeshAgent agent)
    {

        agent.SetDestination(-target.transform.position);
    }


    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        Vector3 randomPoint = center + Random.insideUnitSphere * range;
        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
        {
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }



    //fild of view
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
