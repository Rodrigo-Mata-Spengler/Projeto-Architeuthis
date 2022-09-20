using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTeste : MonoBehaviour
{
    private NPCSpawn npcSpawn;

    bool teset;

    private void Start()
    {
        npcSpawn = transform.GetComponent<NPCSpawn>();
        teset = true;
    }

    private void Update()
    {
        if (teset)
        {
            teset = false;
            npcSpawn.SpawnNpc(0, 0, 4);
            npcSpawn.SpawnNpc(1, 1, 4);
            npcSpawn.SpawnNpc(2, 2, 4);

            //npcSpawn.SpawnNpc(0, 0, 5);
            //npcSpawn.SpawnNpc(1, 1, 4);
            //npcSpawn.SpawnNpc(2, 2, 6);
            
        }
    }
}
