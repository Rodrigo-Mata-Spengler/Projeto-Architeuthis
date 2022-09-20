using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnBeta : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefab; //prefabs dos inimigos

    [SerializeField] private GameObject[] spawnAreas; // locais de spawn

    [SerializeField] private float timeSpawn;//tempo entre spawns de npcs

    public void SpawNpc(int spawnArea, int tipo, int quantidade)
    {
        
        Coroutine teste =  StartCoroutine(Spawn(spawnArea, tipo, quantidade));
        StopCoroutine(teste);
        
    }

    IEnumerator Spawn(int spawnArea, int tipo, int quantidade)
    {
        for (int i = 0; i < quantidade; i++)
        {
            Instantiate(npcPrefab[tipo], spawnAreas[spawnArea].transform.position, spawnAreas[spawnArea].transform.rotation);
            //yield return new WaitForSeconds(timeSpawn);//espera por segundos
        }
        yield break;
    }
}
