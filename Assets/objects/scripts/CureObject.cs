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

    public float cureValue;

    private float MaxLife;
    private float Health;

    [SerializeField] public bool ActiveText = false;
    

    private int Maxlife;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Player.GetComponent<Health>().Life >= 100 )
        {
            IsFullText.enabled = true;
        }
        else
        {
            PressText.enabled = true;

            if (Input.GetKeyDown(KeyCode.F) && Player.GetComponent<Health>().Life < 100)
            {
                Player.GetComponent<Health>().GiveHealth(cureValue);

                

                PressText.enabled = false;
                
                GameObject.Find("GameManager").GetComponent<GameManager>().ActiveText = false;
                IsFullText.enabled = false;
                Destroy(Pai, 0.1f);

                

            }
        }



    }
}
