using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleNpc : MonoBehaviour
{
    public int Maxammo;
    
    public int ammo;

    public float FireRate = 15f;
    [HideInInspector]public float NextTimeToFire = 0f;

    [SerializeField] private GameObject pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform SphereDebug;

    [SerializeField] private float bulletvelocity;

    [SerializeField] private Transform Npc;

    [SerializeField] private float bulletForce;

    private void Start()
    {
        ammo = Maxammo;
    }
    
    public bool Recharge()
    {
        ammo = Maxammo;
        return true;
    }

    public bool Aim(GameObject Player)
    {
        Npc.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));
        //gameObject.transform.LookAt(new Vector3(Player.transform.position.x, -0.5f, Player.transform.position.z));
        return true;
    }
    public bool Fire()
    {
        

        if(ammo > 0 && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            ammo--;

            Vector3 aimDir = (SphereDebug.position - spawnBulletPosition.position).normalized;
            GameObject bullet = GameObject.Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().AddForce(aimDir * bulletForce,ForceMode.Impulse);

            return true;
        }
        else
        {
            return false;
        }
    }
}
