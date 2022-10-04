using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTGoToPlace : BTnode
{
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        GameObject alvo = null;

        float distToPlace = Mathf.Infinity;
        GameObject npc = bt.gameObject;
        GameObject[] Places = GameObject.FindGameObjectsWithTag("Place");
        
        foreach(GameObject place in Places)
        {
            float dist = Vector3.Distance(npc.transform.position, place.transform.position);

            if(dist < distToPlace)
            {
                alvo = place;
                distToPlace = dist;
            }
        }

        if(alvo)
        {
            while(alvo)
            {
                npc.transform.Translate(0,0,3* Time.deltaTime);

                if (Vector3.Distance(npc.transform.position, alvo.transform.position) < 0.3f);
                {
                    status = Status.SUCCESS;
                    break;
                }

                yield return null;
            }
        }
        else if(!alvo)
        {
            status=Status.FAILURE;
        }

        if(status == Status.RUNNING) status = Status.FAILURE;
    }
}
