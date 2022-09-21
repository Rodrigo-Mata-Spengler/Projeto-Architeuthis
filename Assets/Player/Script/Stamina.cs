using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private float MaxStamina;
    public float stamina;
    public Slider StaminaBar;

    public float GiveStaminaVelocity;

    private void Start()
    {
        MaxStamina = stamina; 
    }
    void Update()
    {
        

        if(stamina < MaxStamina)
        {
            GiveStamina(GiveStaminaVelocity * Time.deltaTime);
        }
    }

    public void TakeStamina(float TakeAmout)
    {
        stamina -= TakeAmout;
    }

    public void GiveStamina(float GiveAmout)
    {
        stamina += GiveAmout; 
    }

}
