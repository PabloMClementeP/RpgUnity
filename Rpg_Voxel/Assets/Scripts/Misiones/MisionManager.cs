using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MisionManager : MonoBehaviour
{

    public static MisionManager misionManager;


    [Header("Lista de las misiones en curso")]
    public List<MisionBase> misionesActivas = new List<MisionBase>();    // Lista con las Quest que estan haciendose

    [Header("Punteros a la UI de Mision")]
    public GameObject misionUI;
    public Text nombreMision;
    public Text descripcionMision;

    [Header("Lista de las misiones ya finalizadas")]
    public List<MisionBase> misionesFinalizadas = new List<MisionBase>();    // Lista con las Quest que ye completaron




    void Awake()
    {
        if (misionManager == null)
        {
            misionManager = this;
        }
        else if (misionManager != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }






// ///////////////////////////////////////////////////////////////////////////////////////// //

    //      FUNCIONES de CONSULTA

    public bool MisionDisponible(int misionID)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].id == misionID && misionesActivas[i].progreso == MisionBase.ProgresoMision.DISPONIBLE)
            {
                return true;
            }
        }
        return false;
    }

    public bool MisionAceptada(int misionID)
    {
        for (int i=0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].id == misionID && misionesActivas[i].progreso == MisionBase.ProgresoMision.ACEPTADO)
            {
                return true;
            }
        }
        return false;
    }

    public bool MisionCompletada(int misionID)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].id == misionID && misionesActivas[i].progreso == MisionBase.ProgresoMision.COMPLETADO)
            {
                return true;
            }
        }
        return false;
    }

    public bool MisionFinalizada(int misionID)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].id == misionID && misionesActivas[i].progreso == MisionBase.ProgresoMision.FINALIZADO)
            {
                return true;
            }
        }
        return false;
    }

    public bool DialogoNecesario(int misionId)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].id == misionId && misionesActivas[i].progreso == MisionBase.ProgresoMision.ACEPTADO)
            {
                misionesActivas[i].progreso = MisionBase.ProgresoMision.COMPLETADO;
                return true;
            }
        }
        return false;
    }






    // FUNCIONES de Agregar y Quuitar Mision

    public void AgregoMision(MisionBase mision)
    {
        mision.progreso = MisionBase.ProgresoMision.ACEPTADO;
        misionesActivas.Add(mision);
    }

    public void QuitarMision(MisionBase mision)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].titulo == mision.titulo)
            {
                mision.progreso = MisionBase.ProgresoMision.DISPONIBLE;
                misionesActivas.Remove(misionesActivas[i]);
            }
        }
    }

    public void FinalizarMision(MisionBase mision)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].titulo == mision.titulo)
            {
                //mision.progreso = MisionBase.ProgresoMision.DISPONIBLE;
                misionesFinalizadas.Add(misionesActivas[i]);
                misionesActivas.Remove(misionesActivas[i]);
            }
        }
    }




    // Funciones de Actualizacion de las misiones

    public void AgregarItem(GameObject item)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].tipoMision == MisionBase.TipoDeMision.RECOLECTAR && misionesActivas[i].progreso == MisionBase.ProgresoMision.ACEPTADO)
            {
                if (misionesActivas[i].item.tag == item.tag && misionesActivas[i].cantidadObjObtenidos < misionesActivas[i].cantidadObjRequeridos)
                {
                    misionesActivas[i].cantidadObjObtenidos++;
                    if (misionesActivas[i].cantidadObjObtenidos >= misionesActivas[i].cantidadObjRequeridos)
                    {
                        misionesActivas[i].progreso = MisionBase.ProgresoMision.COMPLETADO;
                    }
                }
            }
        }
    }

    public void ZonaNecesaria(GameObject zona)
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            if (misionesActivas[i].tipoMision == MisionBase.TipoDeMision.UBICACION)
            {
                if (misionesActivas[i].zona == zona)
                {
                    misionesActivas[i].progreso = MisionBase.ProgresoMision.COMPLETADO;
                }
            }
        }
    }






    //    MOSTRAR Y OCULTAR UI DE MISION
    //      Agregando los textos de nombre y descripcion

    public void MostrarUI(MisionBase mision)
    {
        nombreMision.text = mision.titulo;
        descripcionMision.text = mision.descripcion;
        misionUI.SetActive(true);
    }

    public void MisionFinalizadaUI(MisionBase mision)
    {
        nombreMision.text = mision.titulo;
        descripcionMision.text = ("Has ganado: " + mision.dineroGanado + " Oro " + "  Y  Obtenido: " + mision.experienciaGanada + " de Experiencia");
        misionUI.SetActive(true);
    }

    public void OcultarUI()
    {
        misionUI.SetActive(false);
    }




    //**************************************************//
    //**************************************************//
    // Mostrar las misiones activas y su progreso actual

    public void MostrarMisiones()
    {
        for (int i = 0; i < misionesActivas.Count; i++)
        {
            Debug.Log("Mision: " + misionesActivas[i].titulo + "   Cantidad: " + misionesActivas[i].cantidadObjObtenidos + "/" + misionesActivas[i].cantidadObjRequeridos);
        }
    }


}
