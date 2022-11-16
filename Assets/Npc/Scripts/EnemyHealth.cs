using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Life;

    public float maxLife;

    public int pointsGive;

    private int TotalPointsToPass;

    private void Start()
    {
        Life = maxLife;
        
        TotalPointsToPass = GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints;
    }

    private void Awake()
    {
        pointsGive = Random.Range(1, 5);
    }
    void Update()
    {

        if (Life <= 0)
        {

            GameObject.Find("GameManager").GetComponent<GameManager>().CurrentPoints += pointsGive;

            this.gameObject.GetComponent<DropItem>().DropResources();
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

        Destroy(gameObject);
    }

}
