using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTPlaceAvailablev02 : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyCAceteteV01>().SeePlayer;

        GameObject Place = GameObject.FindGameObjectWithTag("Place");

        if (Place && SeePlayer == false)
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
