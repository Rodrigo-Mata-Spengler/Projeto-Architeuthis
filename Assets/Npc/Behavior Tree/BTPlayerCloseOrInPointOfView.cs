using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPlayerCloseOrInPointOfView : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyV01>().distToPlayer;

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyV01>().SeePlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        GameObject npc = bt.gameObject;

        GameObject npcRifleVariant = bt.transform.GetChild(0).gameObject;

        if(SeePlayer == true || Vector3.Distance(npc.transform.position, alvo.transform.position) < distToPlayer || SeePlayer == true)
        {
            status = Status.SUCCESS;
            // npc.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
            //npcRifleVariant.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));

            
        }
        if( status == Status.RUNNING);
        {
            status = Status.FAILURE;
        }
        Print();
        yield break;
    }
}
