using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaminandoNpj : MonoBehaviour
{
    public NavMeshAgent nmAgent;
    public GameObject[] target;

    int i;

    // Start is called before the first frame update
    void Start()
    {
        //nmAgent = GetComponent<NavMeshAgent>();
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target[i].transform.position, transform.position) > 2)
        {
            nmAgent.SetDestination(target[i].transform.position);
            nmAgent.speed = 3;
        }
        else
        {
            if (i< target.Length -1)
            {
                i++;
            }
            else
            {
                i = 0;
            }

        }
    }
}
