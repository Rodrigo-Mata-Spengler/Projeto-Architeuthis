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

    [SerializeField] private GameObject Npc;

    [SerializeField] private float bulletForce;

    public NpcAnimationController animatorController;

    float speed = 1.5f;
    public float reloadTime;

    [Header("RaycastShooter")]
    public float damage;
    public float Range = 100f;
    public LayerMask PlayerLayer;
    public LayerMask AmbienteLayer;
    [Space]
    public ParticleSystem ShootEffect;
    public GameObject ImpactEffect;



    [Header("Sounds")]
    [HideInInspector] public AudioSource AudioSource;

    public AudioClip ShootSound;


    private void Start()
    {
        ammo = Maxammo;
        AudioSource = gameObject.GetComponent<AudioSource>();
    }
    
    public bool Recharge()
    {
        
        ammo = Maxammo;
        return true;
    }
    private void Update()
    {
        Debug.DrawRay(spawnBulletPosition.position, spawnBulletPosition.transform.forward, Color.yellow);
    }
    public bool Aim(GameObject Target)
    {

        //Npc.transform.LookAt(new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z));
        gameObject.transform.LookAt(new Vector3(Target.transform.position.x, Target.transform.position.y, Target.transform.position.z));

        return true;
    }
    public bool Fire()
    {

        animatorController.Shoot = false;

        if (ammo > 0 && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / FireRate;
            ammo--;

            //Vector3 aimDir = (ondeAtirar.position - spawnBulletPosition.position).normalized;
            //GameObject bullet = GameObject.Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            //bullet.GetComponent<Rigidbody>().AddForce(aimDir * bulletForce, ForceMode.Impulse);

            Shoot();

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
    public void Shoot()
    {

        RaycastHit hit;

        ShootEffect.Play();

        if (Physics.Raycast(spawnBulletPosition.transform.position, spawnBulletPosition.transform.forward, out hit, Range, PlayerLayer, QueryTriggerInteraction.Collide))
        {
            Health PlayerHealth = hit.transform.GetComponent<Health>();

            Debug.DrawRay(spawnBulletPosition.position, spawnBulletPosition.transform.forward, Color.yellow);
            if (PlayerHealth != null)
            {
                PlayerHealth.DamageHealth(damage);
            }


        }
        else if (Physics.Raycast(spawnBulletPosition.transform.position, spawnBulletPosition.transform.forward, out hit, Range, AmbienteLayer))
        {
            GameObject ImpactGO = Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);
        }


        AudioSource.PlayOneShot(ShootSound);
    }
}
