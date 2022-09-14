using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina;
    public Slider StaminaBar;
    void Update()
    {
        Staminas(stamina);
    }
    public void Staminas(float stamina)
    {
       // passa o valor das variaveis para o "value" do slider
        StaminaBar.value = stamina;
    }
}
