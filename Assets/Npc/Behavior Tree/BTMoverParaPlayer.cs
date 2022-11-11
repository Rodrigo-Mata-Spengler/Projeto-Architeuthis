using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoverParaPlayer : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject npc = bt.gameObject;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        bool Inplace = bt.gameObject.GetComponent<BTEnemyV01>().InPlace;

        //navmesh
        NavMeshAgent agent = bt.GetComponent<BTEnemyV01>().agent;
        BTEnemyV01 Controller = bt.GetComponent<BTEnemyV01>();

        bool seguir = false;
        while(alvo)
        {

            /*if (Vector3.Distance(npc.transform.position, alvo.transform.position) <= 5f)
            {
                seguir = true;
                
            }*/

            npc.transform.LookAt(alvo.transform.position);
            Controller.MoveToTarget(alvo, agent, 10f);
            status = Status.SUCCESS;
            break;


        }

        Print();
        yield break;
    }
}
