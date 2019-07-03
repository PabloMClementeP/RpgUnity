using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMision : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MisionManager.misionManager.ZonaNecesaria(this.gameObject);
        }
    }

}
