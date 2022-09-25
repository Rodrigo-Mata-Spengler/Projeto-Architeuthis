using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CureObject : MonoBehaviour
{
    public GameObject Player;
    public GameObject Pai;

    public Text PressText;
    public Text IsFullText;

    /*[HideInInspector]
    public float dist;
    public float distToObj;*/

    public float cureValue;

    private float MaxLife;

    [SerializeField] public bool ActiveText = false;
    

    private int Maxlife;

    // Start is called before the first frame update
    void Start()
    {
        MaxLife = Player.GetComponent<Health>().MaxLife;
    }

    // Update is called once per frame
    void Update()
    {
        if(ActiveText == true)
        {
            if (MaxLife >= Player.GetComponent<Health>().MaxLife)
            {
                IsFullText.enabled = true;
            }
            else
            {
                PressText.enabled = true;
            }
        }
        /*dist = Vector3.Distance(Player.transform.position, transform.position);*/

        if (Input.GetKeyDown(KeyCode.F) && Player.GetComponent<Health>().MaxLife < MaxLife)
        {
            Player.GetComponent<Health>().GiveHealth(cureValue);

            Destroy(Pai, 0.1f);
            PressText.enabled = false;


        }
    }
}
