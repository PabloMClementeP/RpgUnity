using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class QuestManager : MonoBehaviour
{



    public static QuestManager questManager;

    [Header("Lista de todas las misiones")]
    public List<Quest> questList = new List<Quest>();           // Lista con todas las Quest

    [Header("Lista de las misiones en curso")]
    public List<Quest> currentQuestList = new List<Quest>();    // Lista con las Quest que estan haciendose

    [Header("Referencias al panel Quest")]
    //Referencia al panel que muestra la quest
    // y a los cuadros text de titulo y descripcion
    public GameObject questPanel;
    public Text tituloText;
    public Text descripcionText;

    //Referencia al boton aceptar del panel Quest
    public Button botonAceptarQuest;

    //String para almacenar la id de la quest que se esta mostrando
    public string id;
    



    //   *************************************************//
    //             Funciones
    // ***************************************************//

    void Awake()
    {
        if (questManager == null)
        {
            questManager = this;
        }
        else if (questManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }


    private void Start()
    {
        // Chequea si es precionado el boton aceptar de la mision UI
        botonAceptarQuest.onClick.AddListener(() => AceptarQuest(id));
    }


    //Agregar Item
    // paso como argumento el indice a la Quest activa
    public void AgregarItem(int index)
    {
        //agrega un item a la cantidad que ya tiene
        questList[index].cantidadObjObtenidos++;

        // si la cantidad que tiene es igual o mayor que la requerida la Quest pasa a ser COMPLETADA
        if (questList[index].cantidadObjObtenidos >= questList[index].cantidadObjRequeridos)
        {
            questList[index].progreso = Quest.QuestProgress.COMPLETADO;
        }
    }

    //Remover Item


    //Aceptar Quest

    public void AceptarQuest(string idQuest)
    {
        for(int i=0; i<questList.Count; i++)
        {
            if (questList[i].id == int.Parse(idQuest) && questList[i].progreso == Quest.QuestProgress.DISPONIBLE)
            {
                currentQuestList.Add(questList[i]);
                questList[i].progreso = Quest.QuestProgress.ACEPTADO;
                questPanel.SetActive(false);
            }
        }
    }

    //Cancelar Quest
    // cierra el panel de la quest si se preciona el boton cancelar
    // (es llamado desde el boton)
    public void CancelarQuest()
    {
        questPanel.SetActive(false);
    }

    //Abandonar Quest

    public void AbandonarQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progreso == Quest.QuestProgress.ACEPTADO)
            {
                questList[i].progreso = Quest.QuestProgress.DISPONIBLE;
                currentQuestList[i].cantidadObjObtenidos = 0;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }


    //Completar Quest

    public void FinalizarQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (currentQuestList[i].id == questID && currentQuestList[i].progreso == Quest.QuestProgress.COMPLETADO)
            {
                questList[i].progreso = Quest.QuestProgress.FINALIZADO;
                currentQuestList.Remove(currentQuestList[i]);
            }
        }
    }


    // Funciones de consulta

    public bool EsQuestDisponible(int questID)
    {
        for (int i=0; i < questList.Count; i++)
        {
            if(questList[i].id == questID && questList[i].progreso == Quest.QuestProgress.DISPONIBLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool EsQuestAceptada(int questID)
    {
        for (int i= 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progreso == Quest.QuestProgress.ACEPTADO)
            {
                return true;
            }
        }
        return false;
    }

    public bool EsQuestFinalizada(int questID)
    {
        for (int i= 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID && questList[i].progreso == Quest.QuestProgress.FINALIZADO)
            {
                return true;
            }
        }
        return false;
    }

    //Chequea que sea un objeto necesario en alguna de las Quest que estan activas
    public bool EsObjetoNecesario(GameObject objeto)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].objetivos == objeto.tag && questList[i].progreso == Quest.QuestProgress.ACEPTADO)
            {
                // si es un objeto requerido por alguna mision compruebo que la cantidad que tiene aun sea menor que la requerida
                if (questList[i].cantidadObjObtenidos < questList[i].cantidadObjRequeridos)
                {
                    //si es necesario y aun no llega a la cantidad requerida llamo agregar item y paso el indice de la lista de Quest activas
                    AgregarItem(i);
                }

                return true;
            }
        }
        return false;
    }



    // Mostrar la quest en la UI de quest para aceptarla
    public void MostrarQuest(int questID)
    {
        for (int i = 0; i < questList.Count; i++)
        {
            if (questList[i].id == questID)
            {
                tituloText.text = questList[i].titulo;
                descripcionText.text = questList[i].descripcion;
                id = questID.ToString();
                questPanel.SetActive(true);
            }
        }
    }
}
