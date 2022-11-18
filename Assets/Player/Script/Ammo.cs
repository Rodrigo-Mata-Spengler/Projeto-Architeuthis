using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
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

    public Transform NormalPosition;
    public Transform AimPosition;
    public Transform MainCamera;
    public Transform Torso;

    private int MaxPistolBag;

    public float AimSpeed;

    [Space]
    public MovePlayer PlayerMoveScript;

    [Space]

    [Header("RecoilSettings")]
    public float rotationSpeed = 6;
    public float returnSpeed = 25;

    [Header("HipFire")]
    public Vector3 RecoilRotation = new Vector3(2.0f, 2.0f, 2.0f);

    [Header("Aiming")]
    public Vector3 RecoilRotationAiming = new Vector3(0.5f, 0.5f, 1.5f);

    [Header("State")]
    public bool aiming;

    private Vector3 currentRotation;
    private Vector3 rot;

    [Header("Cheat")]
    public bool balasInfinitas = false;

    [HideInInspector]
    public Animator HandGunAnimator;

    private bool Reloading = false;
    private bool Isfiring;


    [Header("Sounds")]
    public AudioSource reloadSound;
    public AudioSource OutOfAmmoSound;
    private void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        rot = Vector3.Slerp(rot, currentRotation, rotationSpeed * Time.deltaTime);
        MainCamera.transform.localRotation = Quaternion.Euler(rot);
    }
    private void Start()
    {
       

        HandGunAnimator = GetComponent<Animator>();
        
        ammo = Maxammo;

        MaxPistolBag = MaxBag;
    }
    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variav�l para o texto na tela
        AmmoBagText.text = MaxBag.ToString();

        if (Input.GetKeyDown(KeyCode.R)  && MaxBag > 0 && ammo < Maxammo && Isfiring == false )
        {
            StartCoroutine(Reload(2.3f));
           

        }

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire && ammo > 0 && PlayerMoveScript.IsRunning == false && Reloading == false) //atira
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
           //ShootSound.enabled = false;
        }

        if (Input.GetButton("Fire1") && Time.time >= NextTimeToFire && ammo <= 0 && PlayerMoveScript.IsRunning == false && Reloading == false)
        {
            StartCoroutine(OutSound(0.4f));
        }
        if (Input.GetButton("Fire2"))
        {
            aiming = true;
        }
        else
        {
            aiming = false;
        }

        Aim(Input.GetMouseButton(1));

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
        
    }
    public void Aim(bool IsAiming)
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
