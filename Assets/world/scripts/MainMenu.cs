using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu;
    public GameObject optionsPanel;
    public GameObject comoJogar;
    public GameObject credito;

    public string scenaJogo;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        mainMenu.SetActive(true);
        optionsPanel.SetActive(false);
        comoJogar.SetActive(false);
    }
    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(scenaJogo);
    }
    public void Options()
    {
        mainMenu.SetActive(false);
        optionsPanel.SetActive(true);
        comoJogar.SetActive(false);
        credito.SetActive(false);
    }
    public void ComoJogar()
    {
        mainMenu.SetActive(false);
        optionsPanel.SetActive(false);
        comoJogar.SetActive(true);
        credito.SetActive(false);
    }

    public void VoltarMenu()
    {
        mainMenu.SetActive(true);
        optionsPanel.SetActive(false);
        comoJogar.SetActive(false);
        credito.SetActive(false);
    }
    public void Creditos()
    {
        mainMenu.SetActive(false);
        optionsPanel.SetActive(false);
        comoJogar.SetActive(false);
        credito.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }



}
