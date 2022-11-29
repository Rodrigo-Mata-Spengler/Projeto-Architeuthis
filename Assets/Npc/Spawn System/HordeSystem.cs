using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSystem : MonoBehaviour
{
    [SerializeField] private float tempoHorda;

    private float nextHorde = 0f;

    [SerializeField] private int minSize;

    [SerializeField] private int maxSize;

    [SerializeField] private int maxSizeSpawns;

    [SerializeField] GameObject[] npc;

    [SerializeField] Transform[] spawnArea;

    private int[] hordasize = {0,0,0};

    private int[] hordaSpawn = { 0, 0, 0 };

    [SerializeField] Transform plane;

    [SerializeField] GameObject itemDrop;


    private void Start()
    {
        HordaCreator();
    }

    private void HordaCreator()
    {
        for (int i = 0; i < hordasize.Length; i++)
        {
            hordasize[i] = Random.Range(minSize, maxSize);
        }
        for (int i = 0; i < hordaSpawn.Length; i++)
        {
            hordaSpawn[i] = Random.Range(0, maxSizeSpawns-1);
        }
    }

    private void SpawnHorda()
    {
        StartCoroutine(Spawning());

        HordaCreator();
    }

    IEnumerator Spawning()
    {
        for (int i = 0; i < npc.Length; i++)
        {
            for (int z = 0; z < hordasize[i]; z++)
            {
                GameObject aux = Instantiate(npc[i],spawnArea[hordaSpawn[i]].position, spawnArea[hordaSpawn[i]].rotation);

                if (aux.GetComponent<BTEnemyV01>())
                {
                    aux.GetComponent<BTEnemyV01>().area = plane;

                }else if (aux.GetComponent<BTEnemyCAceteteV01>())
                {
                    aux.GetComponent<BTEnemyCAceteteV01>().area = plane;
                }

                aux.GetComponent<DropItem>().ResourceDrop = Drop();
                yield return new WaitForSeconds(.5f);
            }
            yield return new WaitForSeconds(.5f);
        }
        yield break;
    }

    private void Update()
    {
        if (Time.time >= nextHorde)
        {
            nextHorde = Time.time + tempoHorda;
            SpawnHorda();

        }
    }

    private GameObject Drop()
    {
        GameObject item = itemDrop;
        item.GetComponent<Drops>().Rand();
        return item;
        
    }
}
