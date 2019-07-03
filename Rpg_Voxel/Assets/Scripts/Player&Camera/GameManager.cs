using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class GameManager : MonoBehaviour
    {

        public SistemaInventario Inventario;

    public Text invTxt;
    private bool viendoInv = true;
 

    private void Awake()
        {
            Inventario = new SistemaInventario();
            //Debug.Log("inicio el inventario");
        /*
            InventarioItem tmpInvItem = new InventarioItem();
            tmpInvItem.Categoria = ItemBase.ItemCategoria.Comestible;
            tmpInvItem.Nombre = "ObjetoPrueba";
            tmpInvItem.Descripcion = "Un simple objeto de Prueba";
            tmpInvItem.Valor = 50;
            tmpInvItem.Cantidad = 1;
            Inventario.AgregarItem(tmpInvItem);
        */
        }


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            string texto="";
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                MisionManager.misionManager.MostrarMisiones();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                invTxt.gameObject.SetActive(!viendoInv);
                viendoInv = !viendoInv;
                Inventario.MuestroInventario();
            

                for (int i=0; i < Inventario.todo.Count; i++)
                {
                    texto = texto + Inventario.todo[i] + "\n";
                }
                invTxt.text = " aa";
                invTxt.text = texto;
            }

            //comprobamos que no se precione enter para salir del juego
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }

    }


    public void RpgDestroy(GameObject obj)
    {
        Destroy(obj);
    }
    }
