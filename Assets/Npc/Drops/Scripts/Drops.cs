using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Drops : MonoBehaviour
{
    public enum tipoDrop { Cura, AmmoPistola, AmmoRifle };

    public tipoDrop drop;

    [SerializeField] private float health;
    [SerializeField] private int rifleAmmo;
    [SerializeField] private int pistolaAmmo;
    [SerializeField] private GameObject[] mat;
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
                    if (other.GetComponent<DropReference>().pistola.GetComponent<AmmoPistol>().GiveAmmo(pistolaAmmo))
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
                mat[0].SetActive(true);
                mat[1].SetActive(false);
                mat[2].SetActive(false);
                break;
            case 1:
                drop = tipoDrop.AmmoRifle;
                mat[0].SetActive(false);
                mat[1].SetActive(true);
                mat[2].SetActive(false);
                break;
            case 2:
                drop = tipoDrop.AmmoPistola;
                mat[0].SetActive(false);
                mat[1].SetActive(false);
                mat[2].SetActive(true);
                break;
        }
    }
}
