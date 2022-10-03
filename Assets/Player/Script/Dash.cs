using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private CharacterController controller;

    private Vector3 mov;

    public float dashForca;
    public float dashTime;

    public KeyCode key;

    private void Start()
    {
        controller = transform.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            StartCoroutine(DashTimer());
        }
    }

    IEnumerator DashTimer()
    {
        float starttime = Time.time;

        while (Time.time < starttime+dashTime && GetComponent<Stamina>().stamina > 0)
        {
            controller.Move((Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward) * dashForca * Time.deltaTime);
            GetComponent<Stamina>().stamina -= Time.deltaTime * 18;

            yield return null;
        }
        yield break;
    }
}
