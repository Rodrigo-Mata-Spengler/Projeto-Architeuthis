using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Drops : MonoBehaviour
{
    public enum tipoDrop { Cura, AmmoPistola, AmmoRifle };

    public tipoDrop drop;

    [SerializeField] private float health;
    [SerializeField] private int rifleAmmo;
    [SerializeField] private int pistolaAmmo;
    [SerializeField] private Material[] mat;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            switch (drop)
            {
                case tipoDrop.Cura:
                    if (other.GetComponent<Health>().GiveHealth(health))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case tipoDrop.AmmoPistola:
                    if (other.GetComponent<DropReference>().pistola.GetComponent<Ammo>().GiveAmmo(pistolaAmmo))
                    {
                        Destroy(gameObject);
                    }
                    break;
                case tipoDrop.AmmoRifle:
                    if (other.GetComponent<DropReference>().rifle.GetComponent<Ammo>().GiveAmmo(rifleAmmo))
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }

    public void Rand()
    {
        int a = Random.Range(0,3);

        switch (a)
        {
            case 0:
                drop = tipoDrop.Cura;
                gameObject.GetComponent<MeshRenderer>().material = mat[0];
                break;
            case 1:
                drop = tipoDrop.AmmoRifle;
                gameObject.GetComponent<MeshRenderer>().material = mat[1];
                break;
            case 2:
                drop = tipoDrop.AmmoPistola;
                gameObject.GetComponent<MeshRenderer>().material = mat[2];
                break;
        }
    }
}
