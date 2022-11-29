using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float Life;

    public float maxLife;

    public int pointsGive;

    private int TotalPointsToPass;

    private BTEnemyV01 Brain;
    private NavMeshAgent NavMesh;

    private bool doOnce = true;

    [SerializeField] private Animator pupet;
    [SerializeField] private bool isCacetete;
    [SerializeField] private bool isBoss;

    private BTEnemyCAceteteV01 brainCacetete;

    [Space]
    public NpcAnimationController animatorController;

    [Header("AudioManager")]
    [SerializeField] private AudioSource DeathAudio;

    private bool doOnce2 = false;
    private void Start()
    {
        Life = maxLife;
        
        TotalPointsToPass = GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints;

        brainCacetete = GetComponent<BTEnemyCAceteteV01>();
        Brain = GetComponent<BTEnemyV01>();
        NavMesh = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        pointsGive = Random.Range(1, 5);
    }
    void Update()
    {

        if (Life <= 0 && !doOnce2)
        {
            doOnce2 = true;
            if (isBoss)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints += pointsGive;

            }
            else
            {
                if (isCacetete)
                {
                    NavMesh.enabled = false;
                    brainCacetete.enabled = false;

                    pupet.SetBool("Death", true);
                }
                else
                {
                    NavMesh.enabled = false;
                    Brain.enabled = false;
                    animatorController.Shoot = false;
                    animatorController.Run = false;
                    animatorController.Walk = false;
                    animatorController.Death = true;
                }

                GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints += pointsGive;

                if (doOnce)
                {
                    DeathAudio.enabled = true;
                    NPCReset();
                }
            }
        }
    }

    public void DamageHealth(float damage)
    {
        Life -= damage;


    }
    public void GiveHealth(float cure)
    {
        Life += cure;
    }

    public void NPCReset()
    {
        doOnce = false;
        this.gameObject.GetComponent<DropItem>().DropResources();
        Destroy(gameObject, 2f);

    }

}
