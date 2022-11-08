using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamegeEnemy : MonoBehaviour
{
    private EnemyHealth vida;
    [SerializeField] private float damage;
    private void Start()
    {
        vida = gameObject.GetComponent<EnemyHealfhRef>().vida;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletPlayer"))
        {
            vida.DamageHealth(damage);
            Destroy(other);
        }
    }
}
