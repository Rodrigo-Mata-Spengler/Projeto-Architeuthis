using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMira : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");
        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();

        if (alvo)
        {
            Controller.transform.LookAt(alvo.transform);
            status = Status.RUNNING;
            Print();
        }
        else
        {
            status = Status.FAILURE;
            Print();
            yield return null;
        }
    }
}
