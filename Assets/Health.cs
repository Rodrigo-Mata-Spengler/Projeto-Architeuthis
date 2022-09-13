using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Life;
    public Slider HealthBar;
  
    public void Update()
    {
        HealthStamina(Life);
    }
    public void HealthStamina(float health)
    {
        HealthBar.value = health;// passa o valor das variaveis para o "value" do slider
        
    }

}
