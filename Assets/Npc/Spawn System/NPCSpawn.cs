using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawn : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefab;//modelos base dos npcs para copiar

    [SerializeField] private GameObject[] spawnAreas;//locais de onde os npcs podem spawnar

    [SerializeField] private int[] npcCount;//quantidade de npc de cada tipo que serão criados no começo da cena 

    [SerializeField] private Transform closet;//locais onde os npcs ficam guardados até serem ativados

    [SerializeField] private Vector3 offsetX;

    [SerializeField] private Vector3 offsetz;

    [SerializeField] private float timeSpawn;//tempo entre spawns de npcs

    private GameObject[] npc1; // npcs que exitem no closet do tipo 1
    private GameObject[] npc2; // npcs que exitem no closet do tipo 2
    private GameObject[] npc3; // npcs que exitem no closet do tipo 3

    private int npc1InCloset;
    private int npc2InCloset;
    private int npc3InCloset;

    private void Start()
    {
        npc1 = new GameObject[npcCount[0]];
        npc1InCloset = npc1.Length;

        npc2 = new GameObject[npcCount[1]];
        npc2InCloset = npc2.Length - 1;

        npc3 = new GameObject[npcCount[2]];
        npc3InCloset = npc3.Length - 1;

        Createcloset();
    }

    private void Createcloset()
    {
        Vector3 placeHere = closet.position;

        GameObject npc;

        for (int z = 0; z < npcCount[0]; z++)
        {
            npc = Instantiate(npcPrefab[0], placeHere, transform.rotation);

            npc1[z] = npc;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;

        for (int z = 0; z < npcCount[1]; z++)
        {
            npc = Instantiate(npcPrefab[1], placeHere, transform.rotation);

            npc2[z] = npc;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;

        for (int z = 0; z < npcCount[2]; z++)
        {
            npc = Instantiate(npcPrefab[2], placeHere, transform.rotation);

            npc3[z] = npc;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;
    }

    public bool SpawnNpc(int spawnArea,int tipo,int quantidade)
    {
        bool quanti = false;
        switch (tipo)
        {
            case 0: quanti = npc1.Length >= quantidade;break;
            case 1: quanti = npc2.Length >= quantidade;break;
            case 2: quanti = npc3.Length >= quantidade;break;
            default: quanti = false;break;
        }

        if (spawnAreas.Length >= spawnArea && npcPrefab.Length >= tipo && quanti)
        {
            StartCoroutine(Spawning(spawnAreas[spawnArea], quantidade-1, tipo));
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Spawning(GameObject area, int quantidade, int tipo)
    {
        switch (tipo)
        {
            case 0:
                int aux = npc1InCloset - quantidade;
                Debug.Log(aux);
                for (int i = npc1InCloset-1;i >= aux;i--)
                {
                    //Debug.Log(i);
                    npc1[i].transform.position = area.transform.position;//coloca no local 
                    npc1[i].transform.rotation = area.transform.rotation;//coloca na rotação certa

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }
                //npc1InCloset -= quantidade;
                break;
            case 1:
                for (int i = 0; i <= quantidade;i++)
                {
                    npc2[i].transform.position = area.transform.position;//coloca no local 
                    npc2[i].transform.rotation = area.transform.rotation;//coloca na rotação certa

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }

                break;
            case 2:
                for (int i = 0; i <= quantidade;i++)
                {
                    npc3[i].transform.position = area.transform.position;//coloca no local 
                    npc3[i].transform.rotation = area.transform.rotation;//coloca na rotação certa

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }

                break;
        }

        yield return null;
    }

}
