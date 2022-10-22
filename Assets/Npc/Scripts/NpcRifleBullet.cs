using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRifleBullet : MonoBehaviour
{
    [SerializeField] private float tempoDeVida = 4f;
    public float speed;
    [SerializeField] private float Damage;

    private Rigidbody NPCbulletRb;

    private void Awake()
    {
        NPCbulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        NPCbulletRb.velocity = transform.forward * speed;
    }
    void Update()
    {
        Destroy(gameObject, tempoDeVida);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Health>().DamageHealth(Damage);
            Destroy(gameObject);
        }
        

    }
}
