using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PausePanel;
    public GameObject OptionsPanel;

    public string CreditsSceneName;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Options()
    {
        OptionsPanel.SetActive(true);
    }
    public void Creditos()
    {
        SceneManager.GetSceneByName(CreditsSceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }

}
