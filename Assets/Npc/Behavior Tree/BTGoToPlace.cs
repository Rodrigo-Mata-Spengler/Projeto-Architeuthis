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

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyV01>().SeePlayer;
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

        while(alvo && !SeePlayer)
        {
            if (Vector3.Distance(npc.transform.position, Player.transform.position) < 1f)
            {
                Debug.LogError("é");
                status = Status.FAILURE;

            }
            if (Vector3.Distance(npc.transform.position, alvo.transform.position) > 1f);
            {
                
                Controller.MoveToTarget(alvo, agent);
            }

            yield return null;
        }

        //checar se player esta perto
        if (SeePlayer || !alvo)
        {
           
            status = Status.FAILURE;
            
        }

        Print();
        yield break;
        
    }
}
