using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Health vida;
    [SerializeField] private float damage;

    private void Start()
    {
        vida = gameObject.GetComponent<HealfRef>().Vida;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletNpc"))
        {
            vida.DamageHealth(damage);
            Destroy(other);
        }
    }
}
