using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    public float Life;
    public float Stamina;

    public Slider HealthBar;
    public Slider StaminaBar;

    // Update is called once per frame
    void Update()
    {
        HealthStamina(Life, Stamina);
    }

    public void HealthStamina(float health, float Stamina)
    {
        HealthBar.value = health;// passa o valor das variaveis para o "value" do slider
        StaminaBar.value = Stamina;
    }

}
