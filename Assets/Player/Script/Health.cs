using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Life;
    public float MaxLife;

    public Image LifeIMG1;
    public Image LifeIMG2;
    public Image LifeIMG3;
    public Image LifeIMG4;

    public GameObject painelMorto;

    private bool imortal = false;

    [Header("AudioManager")]
    [SerializeField] private AudioManager AudioManager;

    void Update()
    {
        if(Life<=0)
        {
            AudioManager.Play("Death");
        }
        StartCoroutine(UI());
        if(Life < MaxLife)
        {
            Life += (0.5f * Time.deltaTime);
        }
        
    }

    public void DamageHealth(float damage)
    {
        if (!imortal)
        {
            Life -= damage;
        }
    }
    public bool GiveHealth(float cure)
    {
       float sub = Life + cure;
        if(sub >= MaxLife)
        {
            Life = MaxLife;
            return true;
        }
        else if(sub<= MaxLife)
        {
            Life += cure;
            return true;
        }
        else
        {
            return false;
        }
        
    }
    private IEnumerator UI()
    {
        if (Life < 70)
        {
            //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), text1);
            LifeIMG1.enabled = true;
        }
        else
        {
            LifeIMG1.enabled = false;
        }

        if (Life <= 50)
        {
            LifeIMG2.enabled = true;
        }
        else
        {
            LifeIMG2.enabled = false;
        }

        if (Life <= 10)
        {
            LifeIMG3.enabled = true;
        }
        else
        {
            LifeIMG3.enabled = false;
        }


        if (Life < 0)
        {
            
            //chamar pause aqui
            //chamar painel de morte
            painelMorto.SetActive(true);
            //DeathPanel.SetActive(true);

            yield return new WaitForSeconds(2.0f);
            LifeIMG4.enabled = true;
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            LifeIMG4.enabled = false;
        }

    }

    public void SerImortal()
    {
        imortal = !imortal;
    }
}
