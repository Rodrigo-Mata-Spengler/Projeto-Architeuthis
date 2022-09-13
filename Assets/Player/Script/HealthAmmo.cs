using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    public float Life;
    public float Stamina;

    public int ammo;
    public Text AmmoText;

    public Slider HealthBar;
    public Slider StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString(); //manda o valor da variavél para o texto na tela


        if (Input.GetButtonDown("Fire1") && ammo > 0) //atira
        {
            ammo--;
        }

        HealthStamina(Life, Stamina);
    }

    public void HealthStamina(float health, float Stamina)
    {
        HealthBar.value = health;// passa o valor das variaveis para o "value" do slider
        StaminaBar.value = Stamina;
    }

}
