using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTGoToPlace : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = null;

        float distToPlace = Mathf.Infinity;
        GameObject npc = bt.gameObject;
        GameObject[] Places = GameObject.FindGameObjectsWithTag("Place");

        //navmesh
        NavMeshAgent agent = bt.GetComponent<BTEnemyV01>().agent;
        BTEnemyV01 Controller = bt.GetComponent<BTEnemyV01>();

        foreach (GameObject place in Places)
        {
            float dist = Vector3.Distance(npc.transform.position, place.transform.position);

            if(dist < distToPlace)
            {
                alvo = place;
                distToPlace = dist;
            }
        }

        while(alvo)
        {
            if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 0.3f) ;
            {
                
                Controller.MoveToTarget(alvo, agent);
            }
            if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 0.3f);
            {
                status = Status.SUCCESS;
                break;
            }

            yield return null;
        }
        if(!alvo)
        {
            status=Status.FAILURE;
        }

        if(status == Status.RUNNING) status = Status.FAILURE;

        Print();
    }
}
