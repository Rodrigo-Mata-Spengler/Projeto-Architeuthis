using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector]public int PointsNextLevel;
    public int pointsToPass;

    public Text PressText;
    public Text IsFullText;

    [SerializeField] public bool ActiveText = false;

    [Header("Cheat")]
    public KeyCode KeyCodeCheat;
    public GameObject Player;
    public GameObject Rifle ;
    public GameObject Pistol;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(PointsNextLevel > pointsToPass)
        {
            SceneManager.LoadScene("Scena final");
            //open door or send massage in the UI
        }

        if(ActiveText == false)
        {
            PressText.enabled = false;
            IsFullText.enabled = false;
        }

        /*if(Input.GetKey(KeyCodeCheat))
        {
            Player.GetComponent<Health>().Life = 10000;
            PointsNextLevel = pointsToPass;
            Rifle.GetComponent<Ammo>().MaxBag = 1000;
            Pistol.GetComponent<Ammo>().MaxBag = 1000;
        }*/
    }
    public void GivePointsToPass(int amount)
    {
        PointsNextLevel += amount;
    }
}
