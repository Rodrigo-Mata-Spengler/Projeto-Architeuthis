using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    private float MaxStamina;
    public float stamina;

    public float GiveStaminaVelocity;

    [Header("AudioManager")]
    [SerializeField] private AudioSource TiredAudioInHead;

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

        if(stamina < 10)
        {
            TiredAudioInHead.enabled = true;
        }
        else
        {
            TiredAudioInHead.enabled = false;
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
