using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    
    public enum QuestProgress
        {
            NO_DISPONIBLE,
            DISPONIBLE,
            ACEPTADO,
            COMPLETADO,
            FINALIZADO
        }
    
    public enum TipoDeQuest
        {
            RECOLECTAR = 0,
            UBICACION = 1,
            HABLAR = 2
        }

    public int id;
    public string titulo;
    public string descripcion;

    public QuestProgress progreso;
    public TipoDeQuest tipoQuest;

    public string objetivos;
    public int cantidadObjRequeridos;
    public int cantidadObjObtenidos;

    public int experienciaGanada;
    public int dineroGanado;


}
