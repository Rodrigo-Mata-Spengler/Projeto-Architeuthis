using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    private Rigidbody bulletRb;
    public float speed;
    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
        bulletRb.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        Destroy(gameObject);

    }
}
