using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PointsNextLevel;
    public int pointsToPass;

    public Text PressText;
    public Text IsFullText;

    [SerializeField] public bool ActiveText = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if(PointsNextLevel > pointsToPass)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        PointsNextLevel += amount;
    }
}
