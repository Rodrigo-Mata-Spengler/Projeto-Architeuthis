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

    void Update()
    {
        UI();
    }

    public void DamageHealth(float damage)
    {
        Life -= damage;
  
    }
    public void GiveHealth(float cure)
    {
        Life += cure;
    }


    private void UI()
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

            LifeIMG4.enabled = true;
        }
        else
        {
            LifeIMG4.enabled = false;
        }

    }
}
