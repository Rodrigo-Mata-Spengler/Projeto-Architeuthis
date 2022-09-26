using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private LayerMask aimColliderLayer = new LayerMask();
    [SerializeField] private Transform debugTransform;

    [HideInInspector] public Vector3 mouseWorldPosition ;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayer))
        {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
        }


    }
}
