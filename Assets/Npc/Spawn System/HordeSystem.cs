using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HordeSystem : MonoBehaviour
{
    private List<Horde> hordas;

    [SerializeField] private int hordeMax;

    [SerializeField] private NPCSpawn spawn;

    [SerializeField] private float timeHorde;

    private bool funcionando;
    private void Start()
    {
        spawn.GetComponent<NPCSpawn>();

        hordas.Capacity = hordeMax;

        CreateRound();

        funcionando = false;
    }

    private void Update()
    {
        if (!funcionando)
        {
            HordeExec();
        }
    }

    private Horde HordeCreator()
    {
        Horde horda = new Horde();

        horda.spawnArea = Random.Range(0, spawn.ReturnAreasSize());
        horda.type = Random.Range(0, 2);
        horda.quantidade = spawn.QuantidadeNpc(horda.type);

        return horda;
    }//cria um pequeno pedido de um tipo de npc para a horda

    private void CreateRound()
    {
        for (int i = 0; i < hordeMax; i++)
        {
            hordas.Add(HordeCreator());
        }
    }//monta a horda com varios pedidos

    private void CleanRound()//limpa a lista para o proximo round
    {
        hordas.Clear();
        hordas.Capacity = hordeMax;
    }

    private void HordeExec()
    {
        funcionando = true;
        Coroutine exec=  StartCoroutine(Creator());
    }

    IEnumerator Creator()
    {
        bool exec = false;
        foreach (Horde horda in hordas)
        {
            exec = false;
            exec = spawn.SpawnNpc(horda.spawnArea, horda.type, horda.quantidade);
            if (exec)
            {
                yield return new WaitForSeconds(timeHorde);
            }
            else
            {
                Debug.Log("pedido não atendido");
            }

        }
        CleanRound();
        CreateRound();

        funcionando = false;
        yield break;
    }
}
