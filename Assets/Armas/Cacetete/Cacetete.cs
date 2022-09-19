using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cacetete : MonoBehaviour
{
    [SerializeField] private Animator pupet;

    private void Start()
    {
        pupet.ResetTrigger("Marretar");
    }

    private void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            pupet.SetTrigger("Marretar");
        }
    }
}
