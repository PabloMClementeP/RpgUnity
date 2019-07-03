using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IA_Arania : MonoBehaviour
{

    private GameObject target;
    private NavMeshAgent nmAgent;
    private Animator animator;

    public float distancia;
    private Vector3 posicionInicial;


    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        nmAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        posicionInicial = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < distancia)
        {
            nmAgent.SetDestination(target.transform.position);
            nmAgent.speed = 3;
        }
        else
        {
            nmAgent.SetDestination(posicionInicial);

        }


        if (nmAgent.velocity == Vector3.zero)
        {
            animator.SetBool("Caminando", false);
        }
        else
        {
            animator.SetBool("Caminando", false);
        }

        float vida = gameObject.GetComponent<Healt>().actualVida;
        if(vida <= 0)
        {
            animator.SetBool("Muerto", true);
            Destroy(gameObject, 1f);
        }

    }
}
