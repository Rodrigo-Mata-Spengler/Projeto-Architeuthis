using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public float stamina;
    public Slider StaminaBar;
    // Update is called once per frame
    void Update()
    {
        HealthStamina(stamina);
    }
    public void HealthStamina(float Stamina)
    {
        StaminaBar.value = Stamina;
    }

}
