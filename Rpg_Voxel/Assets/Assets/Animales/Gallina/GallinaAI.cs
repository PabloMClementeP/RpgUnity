using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GallinaAI : MonoBehaviour
{

    private NavMeshAgent nmAgent;
    private Animator animator;
    private GameObject player;
    public float distanciaCorrerPlayer = 4.0f;

    private Vector3 posInicial;

    // Start is called before the first frame update
    void Start()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        posInicial = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        float distancia = Vector3.Distance(transform.position, player.transform.position);
        float distanciaAInicio = Vector3.Distance(transform.position, posInicial);

        if (distancia < distanciaCorrerPlayer )
        {
            Vector3 dirAPlayer = transform.position - player.transform.position;

            Vector3 nuevaPosicion = transform.position + dirAPlayer;

            nmAgent.SetDestination(nuevaPosicion);

            animator.SetBool("Caminando", true);
        }
        else if (distancia > distanciaCorrerPlayer * 3)
        {
            nmAgent.SetDestination(posInicial);
            animator.SetBool("Caminando", true);
        }

        if ( nmAgent.velocity == Vector3.zero )
        {
            animator.SetBool("Caminando", false);
        }
    }
}
