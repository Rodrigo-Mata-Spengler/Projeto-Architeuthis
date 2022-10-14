using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

        
        bool Inplace = bt.gameObject.GetComponent<BTEnemyV01>().InPlace;

        GameObject Player = GameObject.FindGameObjectWithTag("Player");

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
            bool SeePlayer = bt.gameObject.GetComponent<BTEnemyV01>().SeePlayer;

          
            if (SeePlayer == true || Vector3.Distance(npc.transform.position, Player.transform.position) < 3f)
            {
                status = Status.FAILURE;
                break;
            }
            if (Vector3.Distance(npc.transform.position, alvo.transform.position) > 1f)
            {
                
                Controller.MoveToTarget(alvo, agent);
            }

            yield return null;
        }
        if(status == Status.RUNNING) status = Status.FAILURE;

        Print();
        yield break;
        
    }
}
