using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAtirar : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject rifle = bt.gameObject.GetComponent<BTEnemyV01>().rifle;

        if (rifle.GetComponent<RifleNpc>().Fire())
        {
            status = Status.SUCCESS;
            Print();
            yield break;
        }
        else
        {
            status = Status.FAILURE;
            Print();
            yield break;
        }
    }
}
