using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{

    public float maxVida = 10f;
    public float actualVida;
    // Start is called before the first frame update
    void Start()
    {
        actualVida = maxVida;
    }

    // Update is called once per frame
    void Update()
    {
        if (actualVida <= 0)
        {
            //Destroy(gameObject, 1f);
        }
    }

    public void Danio(float valor)
    {
        actualVida -= valor;
    }
}
