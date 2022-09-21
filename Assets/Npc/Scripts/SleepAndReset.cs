using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAndReset : MonoBehaviour
{
    public float tipo;

    public GameObject spawnSistem;
    public void Sleep()
    {
        transform.GetComponent<BTEnemyV01>().enabled = false;
    }

    public void Awake()
    {
        transform.GetComponent<BTEnemyV01>().enabled = true;
    }

    public void BackToCloset()
    {
        transform.GetComponent<BTEnemyV01>().enabled = false;
        spawnSistem.GetComponent<NPCSpawn>().ReCloset(tipo,transform.gameObject);
    }
}
