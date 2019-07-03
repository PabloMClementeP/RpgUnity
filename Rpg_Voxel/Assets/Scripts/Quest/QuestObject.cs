using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestObject : MonoBehaviour
{
    public bool InTrigger;

    public List<int> disponibleQuestID = new List<int>();
    public List<int> porHacerQuestIDs = new List<int>();

    public bool panelPressOpen = false;
    public GameObject panelPress;

    public void Update()
    {
        if (disponibleQuestID.Count > 0)
        {
            if (QuestManager.questManager.EsQuestAceptada(disponibleQuestID[0]))
            {
                porHacerQuestIDs.Add(disponibleQuestID[0]);
                disponibleQuestID.Remove(disponibleQuestID[0]);
            }
        }

        if (InTrigger && Input.GetKeyDown(KeyCode.E))
        {
            // cierro el panel de "Press E"
            panelPressOpen = false;
            panelPress.SetActive(panelPressOpen);


            // si la quest esta disponible la muestro en la UI
            if (disponibleQuestID.Count != 0)
            {
                if (QuestManager.questManager.EsQuestDisponible(disponibleQuestID[0]))
                {
                    QuestManager.questManager.MostrarQuest(disponibleQuestID[0]);
                }
            }
            else
            { 
                Debug.Log("no quedan mas misiones de este tipo");
            }
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InTrigger = true;
            panelPress.SetActive(!panelPressOpen);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            InTrigger = false;
            panelPressOpen = false;
            panelPress.SetActive(panelPressOpen);
        }
    }
}
