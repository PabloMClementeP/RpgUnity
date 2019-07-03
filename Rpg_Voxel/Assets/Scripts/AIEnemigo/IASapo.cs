using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IASapo : MonoBehaviour
{

    public GameObject target;
    public NavMeshAgent nmAgent;

    public float distancia;
    private Vector3 posicionInicial;

    public int vida = 50;
    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        posicionInicial = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if ( Vector3.Distance(target.transform.position, transform.position) < distancia)
        {
            nmAgent.SetDestination(target.transform.position);
            nmAgent.speed = 3;
        }
        else
        {
            nmAgent.SetDestination(posicionInicial);

        }

    }

}
