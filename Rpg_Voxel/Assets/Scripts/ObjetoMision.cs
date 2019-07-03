using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoMision : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            MisionManager.misionManager.AgregarItem(this.gameObject);
        }
    }
        
}
