using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float Life;
    public float Stamina;

    public int ammo;
    public Text AmmoText;

    public Slider HealthBar;
    public Slider StaminaBar;

    // Start is called before the first frame update
    void Start()
    {
        ammo = 0;
        Life = 0;
        Stamina = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AmmoText.text = ammo.ToString();


        if(Input.GetButtonDown("Fire1") && ammo > 0)
        {
            ammo --;
        }

        HealthStamina(Life, Stamina);
    }

    public void HealthStamina(float health, float Stamina)
    {
        HealthBar.value = health;
        StaminaBar.value = Stamina;
    }
}
