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

    private int npc1InCloset;//tamanho atual do armario 1
    private int npc2InCloset;//tamanho atual do armario 2
    private int npc3InCloset;//tamanho atual do armario 3

    private void Start()
    {
        npc1 = new GameObject[npcCount[0]];
        npc1InCloset = npc1.Length;

        npc2 = new GameObject[npcCount[1]];
        npc2InCloset = npc2.Length;

        npc3 = new GameObject[npcCount[2]];
        npc3InCloset = npc3.Length;

        Createcloset();
    }

    private void Createcloset()
    {
        Vector3 placeHere = closet.position;

        GameObject npc;

        for (int z = 0; z < npcCount[0]; z++)
        {
            npc = Instantiate(npcPrefab[0], placeHere, transform.rotation);

            npc.GetComponent<SleepAndReset>().Sleep();

            npc.GetComponent<SleepAndReset>().tipo = 0;

            npc.GetComponent<SleepAndReset>().restPlace = placeHere;

            npc.GetComponent<SleepAndReset>().spawnSistem = transform.gameObject;

            npc1[z] = npc;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;

        for (int z = 0; z < npcCount[1]; z++)
        {
            npc = Instantiate(npcPrefab[1], placeHere, transform.rotation);

            npc.GetComponent<SleepAndReset>().Sleep();

            npc.GetComponent<SleepAndReset>().tipo = 1;

            npc.GetComponent<SleepAndReset>().restPlace = placeHere;

            npc.GetComponent<SleepAndReset>().spawnSistem = transform.gameObject;

            npc2[z] = npc;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;

        for (int z = 0; z < npcCount[2]; z++)
        {
            npc = Instantiate(npcPrefab[2], placeHere, transform.rotation);

            npc.GetComponent<SleepAndReset>().Sleep();

            npc.GetComponent<SleepAndReset>().tipo = 2;

            npc.GetComponent<SleepAndReset>().restPlace = placeHere;

            npc.GetComponent<SleepAndReset>().spawnSistem = transform.gameObject;

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
            Coroutine criacao  = StartCoroutine(Spawning(spawnAreas[spawnArea], quantidade, tipo));
            
            //StopCoroutine(criacao);
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator Spawning(GameObject area, int quantidade, int tipo)
    {
        int aux = 0;
        switch (tipo)
        {
            case 0:
                npc1InCloset -= quantidade;
                foreach (GameObject  npc in npc1)
                {
                    if (npc.GetComponent<SleepAndReset>().awake)
                    {
                        continue;
                    }
                    else
                    {
                        npc.transform.position = area.transform.position;//coloca no local 
                        npc.transform.rotation = area.transform.rotation;//coloca na rotação certa

                        npc.GetComponent<SleepAndReset>().Awake();
                        quantidade--;
                        yield return new WaitForSeconds(timeSpawn);//espera por segundos
                    }

                    if (quantidade == 0)
                    {
                        break;
                    }
                }
                yield break;

                break;
            case 1:
                npc2InCloset -= quantidade;
                foreach (GameObject npc in npc2)
                {
                    if (npc.GetComponent<SleepAndReset>().awake)
                    {
                        continue;
                    }
                    else
                    {
                        npc.transform.position = area.transform.position;//coloca no local 
                        npc.transform.rotation = area.transform.rotation;//coloca na rotação certa

                        npc.GetComponent<SleepAndReset>().Awake();
                        quantidade--;
                        yield return new WaitForSeconds(timeSpawn);//espera por segundos
                    }

                    if (quantidade == 0)
                    {
                        break;
                    }
                }
                yield break;

                break;
            case 2:
                npc3InCloset -= quantidade;
                foreach (GameObject npc in npc3)
                {
                    if (npc.GetComponent<SleepAndReset>().awake)
                    {
                        continue;
                    }
                    else
                    {
                        npc.transform.position = area.transform.position;//coloca no local 
                        npc.transform.rotation = area.transform.rotation;//coloca na rotação certa

                        npc.GetComponent<SleepAndReset>().Awake();
                        quantidade--;
                        yield return new WaitForSeconds(timeSpawn);//espera por segundos
                    }

                    if (quantidade == 0)
                    {
                        break;
                    }
                }
                yield break;

                break;
        }

        yield break;
    }

    public void ReCloset(float tipo,GameObject npcs,Vector3 ogPosition)
    {
        switch (tipo)
        {
            case 0:
                npcs.transform.position = ogPosition;
                npc1InCloset++;

                break;
            case 1:
                npcs.transform.position = ogPosition;
                npc2InCloset++;
                break;
            case 2:
                npcs.transform.position = ogPosition;
                npc3InCloset++;
                break;
        }
    }

}
