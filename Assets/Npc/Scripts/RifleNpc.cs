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
    [SerializeField] private Transform ondeAtirar;

    [SerializeField] private float bulletvelocity;


    [SerializeField] private float bulletForce;

    public NpcAnimationController animatorController;

    float speed = 1.5f;
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
        

        gameObject.transform.LookAt(new Vector3(Player.transform.position.x, Player.transform.position.y, Player.transform.position.z));


        return true;
    }
    public bool Fire()
    {
        animatorController.Shoot = false;

        if (ammo > 0 && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            ammo--;

            Vector3 aimDir = (ondeAtirar.position - spawnBulletPosition.position).normalized;
            GameObject bullet = GameObject.Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().AddForce(aimDir * bulletForce,ForceMode.Impulse);


            animatorController.Shoot = true;
            return true;
        }
        else
        {
            animatorController.Shoot = false;
            animatorController.Run = false;
            animatorController.Walk = false;
            return false;
        }
    }
}
