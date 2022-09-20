using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRifleBullet : MonoBehaviour
{
    [SerializeField] private float tempoDeVida = 4f;
    void Update()
    {
        tempoDeVida -= Time.deltaTime;
        if(tempoDeVida <= 0)
        {
            Destroy(transform.gameObject);
        }
    }
}
