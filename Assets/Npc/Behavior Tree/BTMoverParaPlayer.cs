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
        GameObject npcRifleVariant = bt.transform.GetChild(0).gameObject;

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyV01>().distToPlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        bool Inplace = bt.gameObject.GetComponent<BTEnemyV01>().InPlace;

        //navmesh
        NavMeshAgent agent = bt.GetComponent<BTEnemyV01>().agent;
        BTEnemyV01 Controller = bt.GetComponent<BTEnemyV01>();

        while(alvo)
        {
            

            Debug.LogWarning("ainda rodando");

            if (Vector3.Distance(npc.transform.position, alvo.transform.position) <= 10f)
            {
                
                status = Status.SUCCESS;
                break;
            }
            else
            {
                //npc.transform.Translate(0, 0, 3 * Time.deltaTime);
                Controller.MoveToTarget(alvo, agent, 10f);

            }


            yield return null;
        }

        Print();
        yield break;
    }
}
