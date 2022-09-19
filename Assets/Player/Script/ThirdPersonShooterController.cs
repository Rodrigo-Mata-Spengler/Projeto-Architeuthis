using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderLayer = new LayerMask();
    [SerializeField] private Transform debugTransform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayer))
        {
            debugTransform.position = raycastHit.point;
        }


    }
}
