using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;// Pega o controlador do personagem

    public float sensibilidade; //sensibilidade do movimento do player

    public KeyCode correr;//bot�o para come�ar a corrida

    public float aumentoVelocidade;//multiplicador de velocidade ao correr

    Vector3 mov;

    //variaveis para o pulo
    public float jumpSpeed;//quantidade do pulo
    private float ySpeed;//variavel de velocidade do eixo y
    private float originalStepOffset;

    private Crouch agacha;
    [SerializeField] private float diminuiVelocidade;
    [SerializeField]private float sensicamera;

    private void Start()
    {
        controller = transform.GetComponent<CharacterController>();//pega o controlador do player

        originalStepOffset = controller.stepOffset;

        agacha = transform.GetComponent<Crouch>();
    }

    private void Update()
    {
        float sensi = sensibilidade;
        mov = Input.GetAxis("Vertical") * transform.forward;

        mov += Input.GetAxis("Horizontal") * transform.right;

        if (Input.GetKey(correr) && GetComponent<HealthAmmo>().Stamina > 0)
        {
            sensi *= aumentoVelocidade;
            GetComponent<HealthAmmo>().Stamina -= Time.deltaTime * 6;
        }
        
        if (Input.GetKey(agacha.key))
        {
            sensi *= diminuiVelocidade;
        }
        
        mov *= sensi * Time.deltaTime;

        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }

        mov.y = ySpeed;

        controller.Move(mov);

        transform.Rotate(0, Input.GetAxis("Mouse X") * sensicamera, 0);
    }

    
}
