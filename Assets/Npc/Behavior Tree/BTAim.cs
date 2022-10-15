using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTAim: BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        GameObject rifle = bt.gameObject.GetComponent<BTEnemyV01>().rifle;

        if (rifle.GetComponent<RifleNpc>().Aim(alvo))
        {
            status = Status.SUCCESS;
            Print();
            yield return new WaitForSeconds(1);
        }
        else
        {
            status = Status.FAILURE;
            Print();
            yield break;
        }
        Print();
        yield break;
    }
}
