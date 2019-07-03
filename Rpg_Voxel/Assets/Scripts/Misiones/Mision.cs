using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Mision : MonoBehaviour
{
    [Header("Lista de las misiones que tiene el npj")]
    public List<MisionBase> misiones = new List<MisionBase>();


    private bool InTrigger;

    [Header("Puntero al Panel de Presiona E")]
    public GameObject panelPress;

    private bool panelOpen;

    private bool ultimaMision;

    [Header("Imagenes de sprite estado de mision")]
    public Sprite disponible;
    public Sprite completado;

    public SpriteRenderer estadoIcono;



    private void FixedUpdate()
    {
        if (misiones.Count > 0)
        {
            if (misiones[0].progreso == MisionBase.ProgresoMision.DISPONIBLE)
            {

                // Cambiar icono a disponible
                estadoIcono.sprite = disponible;
            }

            else if (misiones[0].progreso == MisionBase.ProgresoMision.COMPLETADO)
            {
                //cambiar icono a completado 
                estadoIcono.sprite = completado;
                estadoIcono.color = new Color(255, 255, 255, 255);
            }

            else if (misiones[0].progreso == MisionBase.ProgresoMision.ACEPTADO)
            {
                //cambiar icono a completado 
                estadoIcono.sprite = completado;
                estadoIcono.color = new Color(0, 0, 0, 20);
            }
        }
        if (misiones.Count <= 0)
        {
            estadoIcono.sprite = null;
        }
    }

    private void Update()
    {

        if (InTrigger && panelOpen == false && Input.GetKeyDown(KeyCode.E))
        {
            if (panelOpen == false)
            {
                // cierro el panel de "Press E"
                panelPress.SetActive(false);

                if (misiones.Count > 0)
                {
                    //Mision disponible para aceptar
                    if (misiones[0].progreso == MisionBase.ProgresoMision.DISPONIBLE)
                    {
                        MisionManager.misionManager.MostrarUI(misiones[0]);
                        panelOpen = true;
                    }
                    // Si la mision ya fue completada la puedo devolver cobrar y la quito
                    else if (misiones[0].progreso == MisionBase.ProgresoMision.COMPLETADO)
                    {
                        //Muestro que se completo
                        MisionManager.misionManager.MisionFinalizadaUI(misiones[0]);
                        MisionManager.misionManager.FinalizarMision(misiones[0]);
                        misiones.Remove(misiones[0]);

                    }
                }
            }
        }

        // ***********************
        //Si el panel de mision esta abierto chequeo si preciona E para aceptar la mision o Q para cancelar
        // ***********************
        else if (InTrigger && panelOpen && Input.GetKeyDown(KeyCode.E))
        {
            MisionManager.misionManager.AgregoMision(misiones[0]);

            MisionManager.misionManager.OcultarUI();
            panelOpen = false;
        }

        else if (InTrigger && panelOpen && Input.GetKeyDown(KeyCode.Q))
        {
            MisionManager.misionManager.OcultarUI();
            panelOpen = false;
            panelPress.SetActive(true);
        }

    }






    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            InTrigger = true;
            if (misiones.Count >= 1)
            {
                if (misiones[0].progreso != MisionBase.ProgresoMision.ACEPTADO)
                {
                    panelPress.SetActive(true);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InTrigger = false;
            panelPress.SetActive(false);

            MisionManager.misionManager.OcultarUI();
            panelOpen = false;
        }
    }
}
