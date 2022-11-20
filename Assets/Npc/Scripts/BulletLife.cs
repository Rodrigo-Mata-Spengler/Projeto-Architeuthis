using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 2f);
    }
}
