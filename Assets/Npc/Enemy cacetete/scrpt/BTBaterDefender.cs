using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBaterDefender : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();
        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();

        float defender = Controller.porcentagemdefender;

        float resultado = Random.Range(0f, 100f);

        if (resultado <= defender)
        {
            status = Status.FAILURE;
            Print();

            yield return null;
        }
        else 
        {
            status = Status.SUCCESS;
            Print();

            yield return null;
        }

        yield break;
    }
}
