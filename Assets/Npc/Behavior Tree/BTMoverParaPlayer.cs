using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTMoverParaPlayer : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject npc = bt.gameObject;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        while (alvo)
        {

            if(Vector3.Distance(npc.transform.position, alvo.transform.position) > 5)
            {
                npc.transform.LookAt(new Vector3(alvo.transform.position.x, 1, alvo.transform.position.z));
                npc.transform.Translate(0, 0, 3 * Time.deltaTime);
            }
            else if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 10 && Vector3.Distance(npc.transform.position, alvo.transform.position) > 2)
            {
                status = Status.SUCCESS;
                break;
            }
            else if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 2)
            {
                npc.transform.LookAt(alvo.transform.position);
                npc.transform.Translate(0, 0, -2 * Time.deltaTime);
            }



            yield return null;
        }

        if (status == Status.RUNNING)
        {
            status = Status.FAILURE;
        }
        Print();
        yield break;
    }
}
