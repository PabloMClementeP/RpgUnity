using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastController : MonoBehaviour
{
    public float rango = 10f;
    public GameObject inicioRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        // el layermask no detecta a todos los debajo de layer 9
        int layerMask = 1 << 9;

        // invierte la opcion quedando todos menos el 9
        //layerMask = ~layerMask;
        
        if(Physics.Raycast(inicioRay.transform.position, inicioRay.transform.forward, out hit, rango, layerMask))
        {
            //Debug.Log(hit.collider.name);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(inicioRay.transform.position, inicioRay.transform.forward * rango);
    }
}
