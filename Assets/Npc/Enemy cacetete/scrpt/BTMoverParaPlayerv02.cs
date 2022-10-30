using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BTMoverParaPlayerv02 : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject npc = bt.gameObject;

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().distToPlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        bool Inplace = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().InPlace;

        //navmesh
        NavMeshAgent agent = bt.GetComponent<BTEnemyCAceteteV01>().agent;
        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();

        while (alvo)
        {

            //npc.transform.LookAt(new Vector3(0, alvo.transform.position.y, 0));

            if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 1.5f)
            {
                
                //Controller.MoveAwayFromTarget(alvo, agent);
                //npc.transform.Translate(0, 0, -8 * Time.deltaTime);
                status = Status.SUCCESS;

                yield return null;
            }
            else
            {
                //npc.transform.Translate(0, 0, 3 * Time.deltaTime);
                Controller.MoveToTarget(alvo, agent);

            }

            yield return null;
        }
        status = Status.FAILURE;
        Print();
        yield break;
    }
}
