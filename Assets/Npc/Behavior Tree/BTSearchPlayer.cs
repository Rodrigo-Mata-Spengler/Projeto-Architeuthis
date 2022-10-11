using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTSearchPlayer : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        float rotY = 1;

        float distToPlayer = bt.gameObject.GetComponent<BTEnemyV01>().distToPlayer;

        bool SeePlayer = bt.gameObject.GetComponent<BTEnemyV01>().SeePlayer;

        GameObject alvo = GameObject.FindGameObjectWithTag("Player");

        GameObject npc = bt.gameObject;


        rotY = Mathf.Clamp(rotY, -60, 60);

        while(SeePlayer == false || Vector3.Distance(npc.transform.position, alvo.transform.position) > distToPlayer)
        {

            npc.transform.localEulerAngles = new Vector3(0, rotY * Time.deltaTime * 3, 0);

            if(rotY == 60)
            {
                rotY -= 1;
            }
            if (rotY == -60)
            {
                rotY += 1;
            }

            if(SeePlayer == true)
            {
                status = Status.SUCCESS;
                break;
            }

            yield return null;
        }

        if(status == Status.RUNNING)
        {
            status = Status.FAILURE;
        }
        Print();
        yield break;
    }
}
