using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BTAim: BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        GameObject rifle = bt.gameObject.GetComponent<BTEnemyV01>().rifle;

        GameObject npc = bt.gameObject;

        float speed = 1.5f;

        while (rifle.GetComponent<RifleNpc>().Aim(alvo))
        {

            status = Status.SUCCESS;
            Print();
            yield break;
        }
        if(status == Status.RUNNING)
        {
            status = Status.FAILURE;
            Print();
            yield break;
        }
        Print();
        yield break;
    }
}
