using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [System.Serializable]
    public class InventarioItem : ItemBase
    {

        [SerializeField]
        private ItemCategoria categoria;
        [SerializeField]
        private float valor;
        [SerializeField]
        private int cantidad;


        public ItemCategoria Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public float Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

    public void CopioInventarioItem(InventarioItem item)
    {
        categoria = item.categoria;
        valor = item.valor;
        cantidad = item.cantidad;
    }
    }


