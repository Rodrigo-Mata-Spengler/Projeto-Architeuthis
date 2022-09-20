using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int PointsNextLevel;
    public int pointsToPass;

    // Start is called before the first frame update
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
    }
    public void GivePointsToPass(int amount)
    {
        PointsNextLevel += amount;
    }
}
