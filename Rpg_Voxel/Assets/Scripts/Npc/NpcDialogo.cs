using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcDialogo : MonoBehaviour
{
    public string[] dialogo;
    public string nombre;

    public bool esMision;
    public int misionId;

    public bool panelPressOpen = false;
    public GameObject panelPress;
    private bool openDialogo = false;

    private  SistemaDialogo sistemaDialogo;
    private bool inTrigger;



    public void Awake()
    {
        sistemaDialogo = FindObjectOfType<SistemaDialogo>();
    }


    public void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E) && openDialogo == false)
        {
            panelPressOpen = false;
            panelPress.SetActive(panelPressOpen);

            if (MisionManager.misionManager.DialogoNecesario(misionId))
            {
                Debug.Log("dio true DialogoNecesario de la mision  " + misionId);
                //MisionManager.misionManager.MisionCompletada(misionId);
            }

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
        else if (sistemaDialogo.openDialog == false)
        {
            openDialogo = false;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = !inTrigger;
            panelPress.SetActive(!panelPressOpen);
        }

    }

    private void OnTriggerStay(Collider other)
    {


    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            inTrigger = !inTrigger;
            panelPressOpen = false;
            panelPress.SetActive(panelPressOpen);
            openDialogo = false;
            sistemaDialogo.CerrarDialogo();

        }
    }
}
