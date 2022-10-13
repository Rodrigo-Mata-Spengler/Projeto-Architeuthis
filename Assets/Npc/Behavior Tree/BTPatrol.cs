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
        //GameObject target = waypoints[WaypointsIndex];

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyV01>().SeePlayer;
        bool Inplace = bt.gameObject.GetComponent<BTEnemyV01>().InPlace;

        
        while (WaypointsIndex < waypoints.Length && Inplace == false)
        {
            GameObject target = waypoints[WaypointsIndex];

            //Debug.LogWarning(WaypointsIndex);
            
            Debug.LogWarning(SeePlayer);
            if (SeePlayer == true)
            {
                status = Status.FAILURE;
                break;
            }

            if (Vector3.Distance(bt.transform.position, target.transform.position) > 2)
            {

                Controller.UpdateDestination(target, waypoints, WaypointsIndex, agent);
            }
            if (Vector3.Distance(bt.transform.position, target.transform.position) <= 3)
            {
                // Controller.IterateWaypoints(WaypointsIndex, waypoints);

                WaypointsIndex++;
                if (WaypointsIndex == waypoints.Length)
                {
                    WaypointsIndex = 0;
                }

                
            }
            yield return null;
        }

        Print();
        yield break;
    }
}
