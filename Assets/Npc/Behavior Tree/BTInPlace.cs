using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class BTInPlace : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        bool Inplace = bt.gameObject.GetComponent<BTEnemyV01>().InPlace;

        GameObject npc = bt.gameObject;
        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        if (Inplace == true)
        {
            //npc.transform.rotation = Quaternion.Euler(0,bt.gameObject.GetComponent<BTEnemyV01>().Yrotation,0);
            npc.transform.LookAt(new Vector3(alvo.transform.position.x, -0.5f, alvo.transform.position.z));
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
