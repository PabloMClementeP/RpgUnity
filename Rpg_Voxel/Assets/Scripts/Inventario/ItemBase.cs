using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    [System.Serializable]
    public class ItemBase
    {
        public enum ItemCategoria
        {
            Arma = 0,
            Comestible = 1,
            Pocion = 2,
            Objeto = 3
        }

        [SerializeField]
        private string nombre;
        [SerializeField]
        private string descripcion;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
    }
