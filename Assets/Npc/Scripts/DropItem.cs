using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject ResourceDrop;

    public void DropResources()
    {
        Instantiate(ResourceDrop, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }

}
