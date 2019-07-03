using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SistemaDialogo : MonoBehaviour
{
    public static SistemaDialogo Instance { get; set; }

    public GameObject dialogoPanel;
    public Text dialogoText, nombreText;

    public List<string> lineasDialogo = new List<string>();

    public string[] dialogoCompleto;
    public string npcNombre;

    public bool openDialog = false;


    int dialogoIndex;

    private void Awake()
    {
        dialogoPanel.SetActive(false);
        openDialog = false;
                
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        
    }

    public void AgregarNuevoDialogo(string[] lineas, string npcNombre)
    {
        dialogoIndex = 0;
        lineasDialogo = new List<string>(lineas.Length);
        lineasDialogo.AddRange(lineas);

        this.npcNombre = npcNombre;

        CrearDialogo();
    }

    public void CrearDialogo()
    {
        dialogoText.text = lineasDialogo[dialogoIndex];

        nombreText.text = npcNombre;

        dialogoPanel.SetActive(true);
        openDialog = true;

    }

    public void ContiuarDialogo()
    {
        if (dialogoIndex < dialogoCompleto.Length -1)
        {
            dialogoIndex++;
            dialogoText.text = dialogoCompleto[dialogoIndex];
        }
        else
        {
            dialogoPanel.SetActive(false);
            openDialog = false;

        }
    }

    public void CerrarDialogo()
    {
        dialogoPanel.SetActive(false);
        openDialog = false;

    }
}
