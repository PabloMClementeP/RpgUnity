using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_Player : MonoBehaviour
{

    public float rotationSpeed = 450.0f;
    public float walkSpeed = 5.0f;
    public float runSpeed = 8.0f;

    private CharacterController controller;

    private Animator animator;

    float gravedad = 0f;

    private Quaternion targetRotation;

    private bool running = false;

    private bool atacando = false;

    public float tiempoAtaque = 1f;
    float tiempo = 0;

    public GameObject arma;
    private bool armaActiva=false;


    //Healt healt;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        //healt = GetComponent<Healt>();
    }



    private void Update()
    {

        tiempo += Time.deltaTime;
        Vector3 input;// = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        float v = Input.GetAxisRaw("Vertical");
        float h = Input.GetAxisRaw("Horizontal");

        if (h != 0)
        {
            v = 0;
        }
        
        input = new Vector3((int)h, 0, (int)v);

        
        if (input != Vector3.zero)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("Corriendo", true);
                running = true;
            }
            else
            {
                animator.SetBool("Corriendo", false);
                animator.SetBool("Caminando", true);
                running = false;
            }
            targetRotation = Quaternion.LookRotation(input);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
            
        }
        else
        {
            animator.SetBool("Corriendo", false);
            animator.SetBool("Caminando", false);
        }

        if (controller.isGrounded)
        {
            gravedad = 0f;
        }
        else
        {
            gravedad += 0.25f;
            gravedad = Mathf.Clamp(gravedad, 1f, 20f);
        }
        Vector3 gravedadVector = -Vector3.up * gravedad * Time.deltaTime;
        controller.Move(gravedadVector);


        
        /*
        targetRotation = Quaternion.LookRotation(input);
        transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);
        */

        Vector3 motion = input;

        if (running)
        {
            motion *= runSpeed;
        }
        else
        {
            motion *= walkSpeed;
        }
        

        motion += Vector3.up * -8;

        if (!atacando)
        {
            controller.Move(motion * Time.deltaTime);
        }
        


        //Ataque

        //AnimatorStateInfo estadoInfo = animator.GetCurrentAnimatorStateInfo(0);
        //atacando = estadoInfo.IsName("Atacando");
        if (armaActiva)
        {
           if (Input.GetKey(KeyCode.Z))
           {
    //          animator.SetBool("Atacando", true);
                //atacando = true;
                if (tiempo > tiempoAtaque)
                {
                    Ataque();
                }


            }
            
        
        
            if (Input.GetKeyUp(KeyCode.Z))
            {
                animator.SetBool("Atacando", false);
                //atacando = false;
            }
        }

        

        /////////////////////////////////////////////
        /////   Saco o Guardo el arma si preciona la tecla 1
        //////////////////////////////////
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            armaActiva = !armaActiva;
            arma.SetActive(armaActiva);
        }

    }

    void Ataque()
    {


        animator.SetBool("Atacando", true);

        StartCoroutine(QuitoVida());
        

    }



    IEnumerator QuitoVida()
    {
        tiempo = 0;

        Vector3 centro = transform.position + transform.forward + transform.up;
        Vector3 valorMedio = new Vector3(0.5f, 0.7f, 0.5f);


            Debug.Log("Empieza ataque");
            atacando = true;

            Collider[] hits = Physics.OverlapBox(centro, valorMedio, transform.rotation);

                 // Giro hacia el enemigo que estoy pegando
                Vector3 mirar = hits[0].transform.position;
                mirar.x = 0.0f;
                mirar.z = 0.0f;       
            
            foreach (Collider hit in hits)
            {
                Healt healtHit = hit.GetComponent<Healt>();
                if (healtHit)
                {

                    transform.LookAt(mirar);
                    healtHit.Danio(1);
                }
            }

        yield return new WaitForSeconds(1);

        Debug.Log("Termina Ataque");
        atacando = false;
    }

}
