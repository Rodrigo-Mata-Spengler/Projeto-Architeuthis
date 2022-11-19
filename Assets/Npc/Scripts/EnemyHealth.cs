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

    [Space]
    public NpcAnimationController animatorController;
    private void Start()
    {
        Life = maxLife;
        
        TotalPointsToPass = GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints;

        Brain = GetComponent<BTEnemyV01>();
        NavMesh = GetComponent<NavMeshAgent>();
    }

    private void Awake()
    {
        pointsGive = Random.Range(1, 5);
    }
    void Update()
    {

        if (Life <= 0)
        {
            NavMesh.enabled = false;    
            Brain.enabled = false;
            animatorController.Shoot = false;
            animatorController.Run = false;
            animatorController.Walk = false;
            animatorController.Death = true;
            GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints += pointsGive;

            
            NPCReset();

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
        this.gameObject.GetComponent<DropItem>().DropResources();
        Destroy(gameObject, 2f);

    }

}
