using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Forzamos la resolucion cuadrada en pantalla completa
        Screen.SetResolution(800, 800, true);
    }

    // Update is called once per frame
    void Update()
    {
        //Forzar la resolucion si no es cuadrada y pantalla completa
        if (!Screen.fullScreen || Camera.main.aspect != 1)
        {
            Screen.SetResolution(800, 800, true);
            Debug.Log(Screen.resolutions);
        }


        //if (Input.GetKey(KeyCode.Escape)) Application.Quit();

    }
}
