using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefab;//modelos base dos npcs para copiar

    [SerializeField] private GameObject[] spawnAreas;//locais de onde os npcs podem spawnar

    [SerializeField] private float[] npcCount;//quantidade de npc de cada tipo que serão criados no começo da cena 

    [SerializeField] private Transform closet;//locais onde os npcs ficam guardados até serem ativados

    [SerializeField] private Vector3 offsetX;

    [SerializeField] private Vector3 offsetz;

    private GameObject[][] npcInCloset;//contem todos os npcs separados por tipo

    [SerializeField] private float timeSpawn;//tempo entre spawns de npcs

    [SerializeField] private GameObject[,] npcInGame;//npcs sendo usados no momento;
    
    private void Start()
    {
        Createcloset();
    }

    private void Createcloset()
    {
        Vector3 placeHere = closet.position;

        GameObject npc;

        for (int i = 0; i < npcPrefab.Length; i++)
        {
            for (int z = 0; z < npcCount[i]; z++)
            {
                 npc = Instantiate(npcPrefab[i],placeHere,transform.rotation);
                
                npcInCloset[i][z] = npc;

                placeHere += offsetX;
                Debug.Log("entrei");
            }
            placeHere.x = 0f;

            placeHere += offsetz;
        }
    }

    /*public bool SpawnNpc(int spawnArea,int tipo,int quantidade)
    {
        if (spawnAreas.Length >= spawnArea && npcPrefab.Length >= tipo && npcInCloset[tipo].Length >= quantidade)
        {
            StartCoroutine(Spawning(spawnAreas[spawnArea], quantidade, tipo));
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Spawning(GameObject area, int quantidade, int tipo)
    {
        //systema temporario, no futuro tera a função wake e função sleep para os npcs
        for (int i = 0; i <= quantidade; quantidade--)
        {
            npcInGame[tipo][i] = npcInCloset[tipo][quantidade];//muda para a lista de ativos

            npcInGame[tipo][i].transform.position = area.transform.position;//coloca no local 
            npcInGame[tipo][i].transform.rotation = area.transform.rotation;//coloca na rotação certa

            new WaitForSeconds(timeSpawn);//espera por segundos
        }


        yield return null;
    }*/

}
