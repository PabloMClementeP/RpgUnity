using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public string[] dialogo;
    public string nombre;

    private bool openDialogo = false;

    public SistemaDialogo sistemaDialogo;


    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Input.GetKeyDown(KeyCode.E) && openDialogo == false)
        {
            sistemaDialogo.AgregarNuevoDialogo(dialogo, nombre);
            openDialogo = true;
            sistemaDialogo.dialogoCompleto = dialogo;
        }

        //int dialogoIndex = 0;
        if (Input.GetKeyDown(KeyCode.Space) && openDialogo == true)
        {
            sistemaDialogo.ContiuarDialogo();
            //dialogoIndex++;
        }
        else if(sistemaDialogo.openDialog == false)
        {
            openDialogo = false;
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            openDialogo = false;
            sistemaDialogo.CerrarDialogo();
        }
    }
}
