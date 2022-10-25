using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPlayerNotCloseOrInPointOfViewv02 : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().distToPlayer;

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().SeePlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        GameObject npc = bt.gameObject;

        if (SeePlayer == false || Vector3.Distance(npc.transform.position, alvo.transform.position) > distToPlayer)
        {
            //Debug.LogError(SeePlayer);
            status = Status.SUCCESS;

        }
        else
        {
            status = Status.FAILURE;
        }
        Print();
        yield break;
    }
}
