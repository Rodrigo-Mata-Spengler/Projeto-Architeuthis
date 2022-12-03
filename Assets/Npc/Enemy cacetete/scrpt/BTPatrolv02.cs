using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTPatrolv02 : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();
        NavMeshAgent agent = bt.GetComponent<BTEnemyCAceteteV01>().agent;
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        //int WaypointsIndex = 0;
        //GameObject target = waypoints[WaypointsIndex];

        bool Inplace = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().InPlace;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        GameObject npc = bt.gameObject;

        Transform area = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().area;


        //Random Patrol
        while (status == Status.RUNNING)
        {
            bool SeePlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().SeePlayer;
            if (SeePlayer == true || Vector3.Distance(npc.transform.position, alvo.transform.position) < 3f)
            {
                status = Status.FAILURE;
                break;
            }

            if (agent.remainingDistance <= agent.stoppingDistance) //done with path
            {
                Vector3 point;
                if (Controller.RandomPoint(area.position, 20f, out point)) //pass in our centre point and radius of area
                {
                    Debug.DrawRay(point, Vector3.up, Color.blue, 10f); //so you can see with gizmos
                    agent.SetDestination(point);
                }
            }

            yield return null;
        }
        Print();
        yield break;
    }
}
