using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcAnimationController : MonoBehaviour
{
    public bool Shoot;
    public bool Walk;
    public bool Run;
    public bool Death;

    public Animator Animator;

    private void Update()
    {
        //Change(Shoot, Walk, Run, Death);

        Animator.SetBool("Shoot", Shoot);
        Animator.SetBool("Death", Death);
        Animator.SetBool("Run", Run);
        Animator.SetBool("Walk", Walk);
    }

    public bool Change(bool Shoot, bool Walk, bool Run, bool Death)
    {
        if(Death)
        {
            Shoot = false;
            Walk = false;
            Run = false;
        }
        if(Shoot)
        {
            Walk = false;
            Run = false;
            
        }
        if(Run)
        {
            Walk = false;
        }
        else
        {
            Walk = true;
        }
         
        return Shoot;
        return Run;
        return Walk;
        return Death;
        
    }
}
