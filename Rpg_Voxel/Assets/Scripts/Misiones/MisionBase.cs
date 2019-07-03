using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class MisionBase
{
    public enum ProgresoMision { DISPONIBLE, NO_DISPONIBLE, ACEPTADO, COMPLETADO, FINALIZADO }

    public enum TipoDeMision { RECOLECTAR, UBICACION, HABLAR }

    [Header("Datos principales de la mision")]
    public int id;
    public string titulo;
    public string descripcion;

    [Header("Progreso en el que se encuentra")]
    public ProgresoMision progreso;
    [Header("Tipo de mision:")]
    public TipoDeMision tipoMision;

    [Header("Mision ubicacion: ubicacion a llegar")]
    public GameObject zona;

    [Header("Mision hablar: conquien hablar")]
    public GameObject talking;

    [Header("Mision Recolectar: Item a recolectar")]
    public GameObject item;
    public int cantidadObjRequeridos;
    public int cantidadObjObtenidos;

    [Header("Recompensas por completar la mision")]
    public int experienciaGanada;
    public int dineroGanado;
}
