using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public GameObject LookAt;

    [HideInInspector]
    public Vector3 upRecoil;
    public Vector3 originalRotation;
    // Start is called before the first frame update
    void Start()
    {
        originalRotation = LookAt.transform.localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddRecoil()
    {
        LookAt.transform.localEulerAngles += upRecoil;
    }

    public void StopRecoil()
    {
        LookAt.transform.localEulerAngles = originalRotation;
    }
}
