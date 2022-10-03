using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTInversor : BTnode
{
    public List<BTnode> children = new List<BTnode>();
    public override IEnumerator Run(BehaviorTree bt)
    {
        status = Status.RUNNING;
        Print();

        foreach (BTnode child in children)
        {
            yield return bt.StartCoroutine(child.Run(bt));
            if(child.status == Status.FAILURE)
            {
                status = Status.SUCCESS;
                break;
            }
            if(child.status == Status.SUCCESS)
            {
                status = Status.FAILURE;
            }
        }


        Print();
    }
}
