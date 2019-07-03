using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLookCamara : MonoBehaviour
{
    public MainCamera camara;



    // Update is called once per frame
    void Update()
    {
        transform.LookAt(transform.position + camara.transform.rotation * Vector3.back,
                        camara.transform.rotation * Vector3.up);
    }
}
