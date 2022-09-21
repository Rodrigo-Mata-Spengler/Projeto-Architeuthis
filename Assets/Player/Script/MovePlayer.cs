using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    private CharacterController controller;// Pega o controlador do personagem

    [SerializeField] private float sensibilidade; //sensibilidade do movimento do player

    [SerializeField] private KeyCode correr;//bot�o para come�ar a corrida

    [SerializeField] private float aumentoVelocidade;//multiplicador de velocidade ao correr

    Vector3 mov;

    //variaveis para o pulo
    [SerializeField] private float jumpSpeed;//quantidade do pulo
    private float ySpeed;//variavel de velocidade do eixo y
    private float originalStepOffset;
    [SerializeField] private float gravidade;

    private Crouch agacha;//para agachar
    [SerializeField] private float diminuiVelocidade;//diminui a velocidade ao agachar

    [SerializeField] private float sensicamera;//sensibilidade da camera

    [SerializeField] private float gastoStamina = 6;//gasto de estamina

    [SerializeField] private GameObject maincamera;//pega o look at

    [SerializeField] private float maxAngulo;//angulo maximo do eixo x da camera
    [SerializeField] private float minAgulo;//angulo minimo do eixo x da camera

    private float rotation = 0;
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

        if (Input.GetKey(correr) && GetComponent<Stamina>().stamina > 0)
        {
            sensi *= aumentoVelocidade;
            GetComponent<Stamina>().stamina -= Time.deltaTime * gastoStamina;
        }
        
        if (Input.GetKey(agacha.key))
        {
            sensi *= diminuiVelocidade;
        }
        
        mov *= sensi * Time.deltaTime;

        ySpeed += gravidade * Time.deltaTime;

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



        rotation += Input.GetAxis("Mouse Y") * sensicamera;

        rotation = Mathf.Clamp(rotation,minAgulo,maxAngulo);
        maincamera.transform.localEulerAngles = new Vector3(rotation * -1,0,0);
    }

    
}
