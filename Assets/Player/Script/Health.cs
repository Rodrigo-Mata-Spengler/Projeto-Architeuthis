using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Life;
    public Slider HealthBar;


    void Update()
    {
        HealthStamina(Life);
    }

    public void DamageHealth(float damage)
    {
        Life -= damage;

       
    }
    public void GiveHealth(float cure)
    {
        Life += cure;
    }

    public void HealthStamina(float health)
    {
        HealthBar.value = health;// passa o valor das variaveis para o "value" do slider
       
    }

}
