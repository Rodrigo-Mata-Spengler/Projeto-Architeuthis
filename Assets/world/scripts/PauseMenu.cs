using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   
    private bool GameisPaused = false;
    private bool gameCheat = false;

    public GameObject PausePanel;
    public GameObject OptionsPanel;
    public GameObject cheatPanel;

    public GameObject player;

    public Ammo pistola;
    public Ammo rifle;

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

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (gameCheat)
            {
                CheatResume();
            }
            else
            {
                CheatPause();
            }
        }
    }

    public void Pause()
    {
        GameisPaused = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0; 
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<MovePlayer>().camMovimente = false;

    }
    public void Resume()
    {
        Time.timeScale = 1;
        GameisPaused = false;
        PausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<MovePlayer>().camMovimente = true;
    }

    public void CheatPause()
    {
        gameCheat = true;
        cheatPanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        player.GetComponent<MovePlayer>().camMovimente = false;
    }
    public void CheatResume()
    {
        Time.timeScale = 1;
        gameCheat = false;
        cheatPanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        player.GetComponent<MovePlayer>().camMovimente = true;
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
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Scene aux = SceneManager.GetActiveScene();
        SceneManager.LoadScene(aux.name);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void imortal()
    {
        player.GetComponent<Health>().SerImortal();
    }
    public void PistlaBalasInfinitas()
    {
        pistola.BalasInfinitas();
    }
    public void RifleBalasInfinitas()
    {
        rifle.BalasInfinitas();
    }
}
