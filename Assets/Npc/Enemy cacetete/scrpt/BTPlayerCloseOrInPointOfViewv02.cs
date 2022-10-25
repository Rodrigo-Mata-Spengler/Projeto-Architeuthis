using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BTPlayerCloseOrInPointOfViewv02 : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().distToPlayer;

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().SeePlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        GameObject npc = bt.gameObject;

        bool Inplace = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().InPlace;

        if (SeePlayer == true || Vector3.Distance(npc.transform.position, alvo.transform.position) < distToPlayer)
        {
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
