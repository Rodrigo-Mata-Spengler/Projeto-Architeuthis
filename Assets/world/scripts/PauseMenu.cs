using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    private bool GameisPaused = false;

    public GameObject PausePanel;
    public GameObject OptionsPanel;

    public MovePlayer player;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        GameisPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0; 
        Cursor.lockState = CursorLockMode.None;
        player.camMovimente = false;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameisPaused = false;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.camMovimente = true;
    }
    public void Options()
    {
        OptionsPanel.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void ResetScene()
    {
        Pause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
