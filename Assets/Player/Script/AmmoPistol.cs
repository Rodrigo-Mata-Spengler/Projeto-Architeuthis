using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPistol : MonoBehaviour
{
    public int Maxammo;
    [HideInInspector]
    public int ammo;

    public int MaxBag;
    public Text AmmoText;
    public Text AmmoBagText;

    private int subC;

    public float FireRate = 15f;
    private float NextTimeToFire = 0f;

    [SerializeField] private GameObject pfBulletProjectile;
    [SerializeField] private float bulletForce;

    [SerializeField] private Transform spawnBulletPosition;
    [SerializeField] private Transform SphereDebug;

    [SerializeField] private float bulletvelocity;

    //public Transform NormalPosition;
    //public Transform AimPosition;
    public Transform MainCamera;
    public Transform Torso;

    private int MaxPistolBag;

    public float AimSpeed;

    [Space]
    public MovePlayer PlayerMoveScript;

    [Header("RaycastShooter")]
    public float damageHead;
    public float damageBody;
    public float Range = 100f;
    public Camera fpsCam;
    public LayerMask NPCHeadlayer;
    public LayerMask NPCBodylayer;
    public LayerMask AmbienteLayer;
    [Space]
    public ParticleSystem ShootEffect;
    public GameObject ImpactEffect;
    public GameObject BloodEffect;

    [Space]

    [Header("RecoilSettings")]
    public float rotationSpeed = 6;
    public float returnSpeed = 25;

    [Header("HipFire")]
    public Vector3 RecoilRotation = new Vector3(2.0f, 2.0f, 2.0f);

    [Header("Aiming")]
    public Vector3 RecoilRotationAiming = new Vector3(0.5f, 0.5f, 1.5f);

    [Header("State")]
    public bool aiming = false;

    private Vector3 currentRotation;
    private Vector3 rot;

    [Header("Cheat")]
    public bool balasInfinitas = false;

    [HideInInspector]
    public Animator HandGunAnimator;

    private bool Reloading = false;
    private bool Isfiring;


    [Header("Sounds")]
    
    [HideInInspector]public AudioSource AudioSource;

    public AudioSource reloadSound;
    public AudioSource OutOfAmmoSound;

    public AudioClip ShootSound;


    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        rot = Vector3.Slerp(rot, currentRotation, rotationSpeed * Time.deltaTime);
        MainCamera.transform.localRotation = Quaternion.Euler(rot);
    }
    private void Start()
    {
        AudioSource = gameObject.GetComponent<AudioSource>();

        HandGunAnimator = GetComponent<Animator>();
        
        ammo = Maxammo;

        MaxPistolBag = MaxBag;
    }
    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variavél para o texto na tela
        AmmoBagText.text = MaxBag.ToString();

        if (Input.GetKeyDown(KeyCode.R)  && MaxBag > 0 && ammo < Maxammo && Isfiring == false )
        {
            StartCoroutine(Reload(2.3f));
           

        }

        if (Input.GetButtonDown("Fire1") && Time.time >= NextTimeToFire && ammo > 0 && PlayerMoveScript.IsRunning == false && Reloading == false) //atira
        {
            Isfiring = true;
            NextTimeToFire = Time.time + 1f / FireRate;

            if (!balasInfinitas)
            {
                ammo--;
            }
            
            Shoot();
            HandGunAnimator.SetBool("shoot", true);
           

        }
        else
        {
            HandGunAnimator.SetBool("shoot", false);
            Isfiring = false;
        }
        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire && ammo <= 0 && PlayerMoveScript.IsRunning == false && Reloading == false)
        {
            StartCoroutine(OutSound(0.4f));
        }
        /*
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }

        Aim(Input.GetMouseButton(1));
        */
    }

    public bool GiveAmmo(int Ammoamount)
    {
        int aux = MaxBag + Ammoamount;
        if ( aux >= MaxPistolBag)
        {
            MaxBag = MaxPistolBag;
            return true;
        }
        else if(aux <= MaxPistolBag)
        {
            MaxBag +=Ammoamount;
            return true;
        }
        else
        {
            return false;
        }

    }
    public void Shoot()
    {
        RaycastHit hit;

        ShootEffect.Play();

        currentRotation += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));

        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range,NPCHeadlayer, QueryTriggerInteraction.Collide))
        {
            Debug.LogError(hit.transform.name);
            EnemyHealth NPCHealth = hit.transform.GetComponent<EnemyHealth>();

            if(NPCHealth != null)
            {
                GameObject BloodGO = Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(BloodGO, 0.5f);
                NPCHealth.DamageHealth(damageHead);
            }
            

        }
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range, NPCBodylayer, QueryTriggerInteraction.Collide))
        {
            EnemyHealth NPCHealth = hit.transform.GetComponent<EnemyHealth>();
           

            if (NPCHealth != null)
            {
                GameObject BloodGO = Instantiate(BloodEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(BloodGO, 0.5f);
                NPCHealth.DamageHealth(damageBody);
                hit.transform.GetComponent<BTEnemyV01>().SeePlayer = true;
            }

            
        }
        else if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, Range, AmbienteLayer))
        {
           GameObject ImpactGO =  Instantiate(ImpactEffect, hit.point, Quaternion.LookRotation(hit.normal));
            Destroy(ImpactGO, 2f);
        }

        AudioSource.PlayOneShot(ShootSound);

        /*

        if (aiming)
        {
            Vector3 aimDir = (SphereDebug.position - spawnBulletPosition.position).normalized;
            GameObject bullet = GameObject.Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().AddForce(aimDir * bulletForce, ForceMode.Impulse);

            currentRotation += new Vector3(-RecoilRotationAiming.x, Random.Range(-RecoilRotationAiming.y, RecoilRotationAiming.y), Random.Range(-RecoilRotationAiming.z, RecoilRotationAiming.z));

        }
        else
        {
            Vector3 aimDir = (SphereDebug.position - spawnBulletPosition.position).normalized;
            GameObject bullet = GameObject.Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
            bullet.GetComponent<Rigidbody>().AddForce(aimDir * bulletForce, ForceMode.Impulse);

            currentRotation += new Vector3(-RecoilRotation.x, Random.Range(-RecoilRotation.y, RecoilRotation.y), Random.Range(-RecoilRotation.z, RecoilRotation.z));
        }
        */
    }
    /*ublic void Aim(bool IsAiming)
    {

        if(IsAiming)
        {
            Torso.position = Vector3.Lerp(Torso.position, AimPosition.position, Time.deltaTime * AimSpeed);
            
        }
        else
        {
            Torso.position = Vector3.Lerp(Torso.position, NormalPosition.position, Time.deltaTime * AimSpeed);
        }
    }
        */
    public IEnumerator Reload(float seconds)
    {
        Reloading = true;
        HandGunAnimator.SetBool("Reloading", true);

        reloadSound.enabled = true;

        yield return new WaitForSeconds(seconds);

        Reloading = false;
        HandGunAnimator.SetBool("Reloading", false);

        if (MaxBag <= 30)
        {
            int subB = (ammo - MaxBag) * -1;
            ammo += subB;
            MaxBag -= subB;
        }
        if ((MaxBag + ammo) < 30)
        {
            ammo = MaxBag + ammo;

            MaxBag -= MaxBag;
        }
        else
        {
            int sub = ammo - Maxammo;
            sub = sub * -1;
            ammo += sub;
            MaxBag -= sub;
        }
        reloadSound.enabled = false;
    }

    public IEnumerator OutSound(float seconds)
    {
        OutOfAmmoSound.enabled = true;

        yield return new WaitForSeconds(seconds);

        OutOfAmmoSound.enabled = false;
    }
    public void BalasInfinitas()
    {
        balasInfinitas = !balasInfinitas;
    }
}
