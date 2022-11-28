using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{

    private Health vida;
    [SerializeField] private float damage;
    [SerializeField] private GameObject cacetete;

    [Header("AudioManager")]
    [SerializeField] private AudioManager AudioManager;

    private void Start()
    {
        vida = gameObject.GetComponent<HealfRef>().Vida;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BulletNpc"))
        {
            if (cacetete.active == true)
            {
                if (Input.GetButton("Fire2") == false)
                {
                    vida.DamageHealth(damage);
                    AudioManager.Play("Damage");
                }
            }
            else
            {
                vida.DamageHealth(damage);
                AudioManager.Play("Damage");
                Destroy(other);
            }
            
        }
    }
}
