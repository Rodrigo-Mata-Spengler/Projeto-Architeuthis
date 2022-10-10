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


        //navmesh
        NavMeshAgent agent = bt.GetComponent<BTEnemyV01>().agent;
        BTEnemyV01 Controller = bt.GetComponent<BTEnemyV01>();

        while (alvo)
        {

            if(Vector3.Distance(npc.transform.position, alvo.transform.position) < distToPlayer)
            {
                npc.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
                //npc.transform.Translate(0, 0, 3 * Time.deltaTime);

                Controller.MoveToPlayer(alvo, agent);

                npcRifleVariant.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
            }
            else if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 10 && Vector3.Distance(npc.transform.position, alvo.transform.position) < 2)
            {
                status = Status.SUCCESS;
                break;
            }
            else if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 2)
            {
                npc.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
                npc.transform.Translate(0, 0, -2 * Time.deltaTime);

                npcRifleVariant.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
            }



            yield return null;
        }

        if (status == Status.RUNNING)
        {
            status = Status.FAILURE;
        }
        Print();
        yield break;
    }
}
