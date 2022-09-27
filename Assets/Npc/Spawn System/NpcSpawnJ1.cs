using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NpcSpawnJ1 : MonoBehaviour
{
    /*private NPCSpawnBeta npcSpawn;

    public float spawntime;

    private float nextSpawn = 0;

    public float gameTime;

    private int random;

    private void Start()
    {
        npcSpawn = transform.GetComponent<NPCSpawnBeta>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {

        if (Time.time >= nextSpawn)
        {
            random = Random.Range(0,1);
            switch (random)
            {
                case 0:
                    npcSpawn.SpawNpc(0, 0, Random.Range(0, 4));
                    break;
                case 1:
                    npcSpawn.SpawNpc(0, 1, Random.Range(0, 4));
                    break;
                default:
                    break;
            }
            nextSpawn = Time.time + spawntime;
        }
        if(Time.time >= gameTime)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }*/
}
