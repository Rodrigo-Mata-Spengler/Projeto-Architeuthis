using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    Animator anim;
    public Transform target;
    float weight;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    private void Update()
    {
        float valor = Input.GetAxis("Vertical");
        float JumpValor = Input.GetAxis("Jump");

        anim.SetFloat("velocidade", valor);
        anim.SetFloat("jump", JumpValor);
    }

    private void OnAnimatorIK()
    {
        if(target)
        {
            Vector3 targetDirection = target.position - transform.position;
            float angulo = Vector3.Angle(targetDirection, transform.forward);

            if (angulo < 75)
            {
                weight = Mathf.MoveTowards(weight, 1, 0.1f);

            }
            else
            {
                weight = Mathf.MoveTowards(weight, 0, 0.02f);   
            }

            anim.SetLookAtPosition(target.position);
            anim.SetLookAtWeight(weight);

            anim.SetIKPosition(AvatarIKGoal.LeftHand, target.position);
            anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, weight / 3);

            anim.SetIKPosition(AvatarIKGoal.RightHand, target.position);
            anim.SetIKPositionWeight(AvatarIKGoal.RightHand, weight / 3);


        }
    }

}
