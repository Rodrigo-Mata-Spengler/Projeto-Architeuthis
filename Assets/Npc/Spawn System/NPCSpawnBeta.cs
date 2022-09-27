using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSpawnBeta : MonoBehaviour
{
    [SerializeField] private GameObject[] npcPrefab;//modelos base dos npcs para copiar

    [SerializeField] private GameObject[] spawnAreas;//locais de onde os npcs podem spawnar

    [SerializeField] private int[] npcCount;//quantidade de npc de cada tipo que ser�o criados no come�o da cena 

    [SerializeField] private Transform closet;//locais onde os npcs ficam guardados at� serem ativados

    [SerializeField] private Vector3 offsetX;

    [SerializeField] private Vector3 offsetz;

    [SerializeField] private float timeSpawn;//tempo entre spawns de npcs

    private List<GameObject> npc1; // npcs que exitem no closet do tipo 1
    private List<GameObject> npc2; // npcs que exitem no closet do tipo 2
    private List<GameObject> npc3; // npcs que exitem no closet do tipo 3

    private int npc1InCloset;//tamanho atual do armario 1
    private int npc2InCloset;//tamanho atual do armario 2
    private int npc3InCloset;//tamanho atual do armario 3

    private void Start()
    {
        npc1.Capacity = 100;
        npc1InCloset = 0;

        npc2.Capacity = 100;
        npc2InCloset = 0;

        npc3.Capacity = 100;
        npc3InCloset = 0;
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

            npc1.Add(npc);

            npc1InCloset++;

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

            npc2.Add(npc);

            npc2InCloset++;

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

            npc3.Add(npc);

            npc3InCloset++;

            placeHere += offsetX;
        }
        placeHere.x = 0f;

        placeHere += offsetz;
    }

    public bool SpawnNpc(int spawnArea, int tipo, int quantidade)
    {
        bool quanti = false;
        switch (tipo)
        {
            case 0: quanti = npc1.Count >= quantidade; break;
            case 1: quanti = npc2.Count >= quantidade; break;
            case 2: quanti = npc3.Count >= quantidade; break;
            default: quanti = false; break;
        }

        if (spawnAreas.Length >= spawnArea && npcPrefab.Length >= tipo && quanti)
        {
            Coroutine criacao = StartCoroutine(Spawning(spawnAreas[spawnArea], quantidade, tipo));
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
        GameObject npc = null;
        switch (tipo)
        {
            case 0:

                aux = npc1InCloset - quantidade - 1;
                for (int i = npc1InCloset - 1; i >= aux; i--)
                {
                    npc = npc1[i];
                    npc1.RemoveAt(i);

                    npc.transform.position = area.transform.position;//coloca no local 
                    npc.transform.rotation = area.transform.rotation;//coloca na rota��o certa

                    npc.GetComponent<SleepAndReset>().Awake();

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }
                npc1InCloset = npc1InCloset - quantidade;
                yield break;

                break;
            case 1:
                aux = npc2InCloset - quantidade - 1;

                for (int i = npc2InCloset - 1; i >= aux; i--)
                {
                    npc = npc2[i];
                    npc2.RemoveAt(i);

                    npc.transform.position = area.transform.position;//coloca no local 
                    npc.transform.rotation = area.transform.rotation;//coloca na rota��o certa

                    npc.GetComponent<SleepAndReset>().Awake();

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }
                npc2InCloset -= quantidade;
                yield break;
                break;
            case 2:
                aux = npc3InCloset - quantidade - 1;

                for (int i = npc3InCloset - 1; i >= aux; i--)
                {
                    npc = npc3[i];
                    npc3.RemoveAt(i);

                    npc.transform.position = area.transform.position;//coloca no local 
                    npc.transform.rotation = area.transform.rotation;//coloca na rota��o certa

                    npc.GetComponent<SleepAndReset>().Awake();

                    yield return new WaitForSeconds(timeSpawn);//espera por segundos
                }
                npc3InCloset -= quantidade;
                yield break;
                break;
        }

        yield break;
    }

    public void ReCloset(float tipo, GameObject npcs, Vector3 ogPosition)
    {
        switch (tipo)
        {
            case 0:
                npcs.transform.position = ogPosition;
                npc1.Add(npcs);
                npc1InCloset++;
                break;
            case 1:
                npcs.transform.position = ogPosition;
                npc2.Add(npcs);
                npc2InCloset++;
                break;
            case 2:
                npcs.transform.position = ogPosition;
                npc3.Add(npcs);
                npc3InCloset++;
                break;
            default:
                break;
        }
    }
}
