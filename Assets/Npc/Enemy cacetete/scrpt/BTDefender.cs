using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTDefender : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        BTEnemyCAceteteV01 Controller = bt.GetComponent<BTEnemyCAceteteV01>();

        Cacetete2 arma = Controller.Cacetete;

        arma.Defender();

        yield return new WaitForSeconds(Random.Range(1,3));

        arma.Soltar();

        status = Status.SUCCESS;
        Print();
        yield return new WaitForSeconds(.5f);


        yield return null;
    }
}
