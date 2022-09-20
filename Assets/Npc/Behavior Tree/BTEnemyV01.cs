using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTEnemyV01 : MonoBehaviour
{
    public GameObject rifle;

    private void Start()
    {
        BTSelector ammo = new BTSelector();

        ammo.children.Add(new BTVerificarBalas());
        ammo.children.Add(new BTRecarregar());

        BTSequance arma = new BTSequance();

        arma.children.Add(ammo);
        arma.children.Add(new BTAtirar());

        BTSequance Enemy = new BTSequance();

        Enemy.children.Add(new BTFindPlayer());
        Enemy.children.Add(new BTMoverParaPlayer());
        Enemy.children.Add(arma);

        BehaviorTree bt = GetComponent<BehaviorTree>();
        bt.root = Enemy;

        StartCoroutine(bt.Execute());
    }
}
