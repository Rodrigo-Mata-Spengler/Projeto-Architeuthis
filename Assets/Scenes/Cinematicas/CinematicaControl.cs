using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CinematicaControl : MonoBehaviour
{
    public VideoPlayer cena;

    public string proximaScena = "Main Menu";

    private bool ctrl = false;

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            cena.Pause();
            SceneManager.LoadScene(proximaScena);
        }

        if (!cena.isPlaying && ctrl)
        {
            SceneManager.LoadScene(proximaScena);
        }
    }

    private void LateUpdate()
    {
        cena.Play();
        if (cena.isPlaying)
        {
            ctrl = true;
        }
    }
}
