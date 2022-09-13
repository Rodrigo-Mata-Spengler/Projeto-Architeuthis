using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBase : MonoBehaviour
{
    [SerializeField] private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    public bool CheckStatus()
    {
        return isActive;
    }

    public void flipStatus()
    {
        isActive = !isActive;
    }
}
