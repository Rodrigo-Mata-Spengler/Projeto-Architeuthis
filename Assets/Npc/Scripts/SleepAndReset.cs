using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepAndReset : MonoBehaviour
{
    public float tipo;

    public GameObject spawnSistem;

    public bool awake;

    public Vector3 restPlace;

    private void Start()
    {
        awake = false;
    }
    public void Sleep()
    {
        transform.GetComponent<BTEnemyV01>().enabled = false;
        awake = false;
    }

    public void Awake()
    {
        transform.GetComponent<BTEnemyV01>().enabled = true;
        awake = true;
    }

    public void BackToCloset()
    {
        Sleep();
        GetComponent<BTEnemyV01>().Sleep();
        spawnSistem.GetComponent<NPCSpawn>().ReCloset(tipo,transform.gameObject,restPlace);
    }
}
