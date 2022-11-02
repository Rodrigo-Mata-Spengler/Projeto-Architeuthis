using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTBater : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();

        Cacetete2 arma = Controller.Cacetete;

        arma.Atacar();

        status = Status.SUCCESS;
        Print();

        yield return new WaitForSeconds(.6f);

        yield return null;

    }
}
