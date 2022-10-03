using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    private CharacterController controller;

    [SerializeField] private float crouchTime = 0.25f;//tempo para agachar e levantar

    [SerializeField] private float curentHeight = 2f;//altura atual do controlador
    [SerializeField] private float targettHeight = 0.5f;//altura do controlador agachado

    [SerializeField] private Vector3 currenteCenter = new Vector3(0, 0, 0);//centro atual do controlador
    [SerializeField] private Vector3 targetCenter = new Vector3(0, 0.5f, 0);//centro do controlador agachado

    public KeyCode key;//botão para apertar

    private void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(CrounchTimer());
        }else if (Input.GetKeyUp(key))
        {
            StartCoroutine(UnCrounchTimer());
        }
    }

    IEnumerator CrounchTimer()
    {
        float starttime = 0;

        while (starttime < crouchTime)
        {
            controller.height = Mathf.Lerp(curentHeight,targettHeight,starttime/crouchTime);
            controller.center = Vector3.Lerp(currenteCenter, targetCenter, starttime/crouchTime);

            starttime += Time.deltaTime;

            yield return null;
        }

        controller.height = targettHeight;
        controller.center = targetCenter;
        yield break;
    }

    IEnumerator UnCrounchTimer()
    {
        float starttime = 0;

        while (starttime < crouchTime)
        {
            controller.height = Mathf.Lerp(targettHeight, curentHeight, starttime/crouchTime);
            controller.center = Vector3.Lerp(targetCenter, currenteCenter, starttime/crouchTime);

            starttime += Time.deltaTime;

            yield return null;
        }

        controller.height = curentHeight;
        controller.center = currenteCenter;
        yield break;
    }
}
