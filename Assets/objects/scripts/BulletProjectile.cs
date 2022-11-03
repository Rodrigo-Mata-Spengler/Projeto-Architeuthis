using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float tempoDeVida = 4f;
    private Rigidbody bulletRb;
    public float speed;

    [SerializeField] private float Damage;
    private void Awake()
    {
        bulletRb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        
        bulletRb.velocity = transform.forward * speed;
    }
    private void Update()
    {
        Destroy(gameObject, tempoDeVida);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyHealth>().DamageHealth(Damage);

            if (other.GetComponent<BTEnemyV01>())
            {
                other.GetComponent<BTEnemyV01>().SeePlayer = true;
            }
            else if (other.GetComponent<BTEnemyCAceteteV01>())
            {
                other.GetComponent<BTEnemyCAceteteV01>().SeePlayer = true;
            }
            
            

            Destroy(gameObject, 0.2f);
        }
        

    }
}
