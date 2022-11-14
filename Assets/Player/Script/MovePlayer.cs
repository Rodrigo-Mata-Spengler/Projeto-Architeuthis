using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
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

    [SerializeField] private GameObject Head;//pega o look at

    [SerializeField] private float maxAngulo;//angulo maximo do eixo x da camera
    [SerializeField] private float minAgulo;//angulo minimo do eixo x da camera


    public bool camMovimente;

     public bool IsRunning = false;

    [Header("Animation")]
    public Animator FpsController;
    public Animator FpsControllerPistol;
    public Animator FpsControllerBat;
    private float WalkAnimation;

    private float rotation = 0;
    private void Start()
    {
        controller = transform.GetComponent<CharacterController>();//pega o controlador do player

        originalStepOffset = controller.stepOffset;

        agacha = transform.GetComponent<Crouch>();

        camMovimente = true;
    }

    private void Update()
    {
        float sensi = sensibilidade;
        mov = Input.GetAxis("Vertical") * transform.forward;

        mov += Input.GetAxis("Horizontal") * transform.right;


        WalkAnimation = (Input.GetAxis("Vertical")*-1) + (Input.GetAxis("Horizontal") * 2);
        FpsController.SetFloat("Walk", WalkAnimation);
        FpsControllerPistol.SetFloat("Walk", WalkAnimation);
        FpsControllerBat.SetFloat("Walk", WalkAnimation);




        if (Input.GetKey(correr) && GetComponent<Stamina>().stamina > 0)
        {
            sensi *= aumentoVelocidade;
            GetComponent<Stamina>().stamina -= Time.deltaTime * gastoStamina;
            FpsController.SetBool("Run",true);
            FpsControllerPistol.SetBool("Run", true);
            FpsControllerBat.SetBool("Run", true);

            IsRunning = true;

        }
        if (Input.GetKeyUp(correr))
        {
            FpsController.SetBool("Run", false);
            FpsControllerPistol.SetBool("Run", false);
            FpsControllerBat.SetBool("Run", false);
            IsRunning = false;
        }

        if (Input.GetKey(agacha.key))
        {
            sensi *= diminuiVelocidade;
        }
        
        mov *= sensi;

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

        controller.Move(mov * Time.deltaTime);
        if (camMovimente)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensicamera, 0);

            rotation += Input.GetAxis("Mouse Y") * sensicamera;

            rotation = Mathf.Clamp(rotation, minAgulo, maxAngulo);
            Head.transform.localEulerAngles = new Vector3(rotation * -1, 0, 0);
        }
        
    }

    
}
