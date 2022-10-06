using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTPatrol : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        BTEnemyV01 Controller = bt.GetComponent<BTEnemyV01>();
        NavMeshAgent agent = bt.GetComponent<BTEnemyV01>().agent;
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag("WayPoint");
        int WaypointsIndex = 0;
        GameObject target = waypoints[WaypointsIndex];

        if (Vector3.Distance(bt.transform.position, target.transform.position) < 1)
        {
            Controller.IterateWaypoints(WaypointsIndex,waypoints);
            Controller.UpdateDestination(target, waypoints, WaypointsIndex, agent);
        }

        yield return null;
    }
}
