using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int CurrentPoints;
    public int pointsToPass;

    public Text PressText;
    public Text IsFullText;

    [SerializeField]public bool ActiveText = false;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentPoints > pointsToPass)
        {
            SceneManager.LoadScene("Scena final");
            //open door or send massage in the UI
        }

        if(ActiveText == false)
        {
            PressText.enabled = false;
            IsFullText.enabled = false;
        }
    }
    public void GivePointsToPass(int amount)
    {
        CurrentPoints += amount;
    }
}
