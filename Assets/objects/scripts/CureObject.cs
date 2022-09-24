using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureObject : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pai;

    public Text PressText;

    /*[HideInInspector]
    public float dist;
    public float distToObj;*/

    public float cureValue;

    private float MaxLife;

    
    // Start is called before the first frame update
    void Start()
    {
        MaxLife = Player.GetComponent<Health>().Life;
        PressText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*dist = Vector3.Distance(Player.transform.position, transform.position);*/

        if (Input.GetKeyDown(KeyCode.F) /*&& dist < distToObj*/)
        {
            Player.GetComponent<Health>().GiveHealth(cureValue);

            Destroy(Pai, 0.1f);
            PressText.enabled = false;


        }
    }
}
