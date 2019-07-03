using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SistemaInventario
    {

        [SerializeField]
        private List<InventarioItem> armas = new List<InventarioItem>();
        [SerializeField]
        private List<InventarioItem> comestibles = new List<InventarioItem>();
        [SerializeField]
        private List<InventarioItem> pociones = new List<InventarioItem>();
        [SerializeField]
        private List<InventarioItem> objetos = new List<InventarioItem>();

    
        private InventarioItem armaSeleccionada;

        public List<string> todo = new List<string>();

        public InventarioItem ArmaSeleccionada
        {
            get { return armaSeleccionada; }
            set { armaSeleccionada = value; }
        }
            
        public SistemaInventario()
        {
            ClearInventario();
        }
       
        public void ClearInventario()
        {
            armas.Clear();
            comestibles.Clear();
            pociones.Clear();
            objetos.Clear();
        }

        //  Funcion Agregar un Item
        public void AgregarItem(InventarioItem item)
        {
            switch (item.Categoria)
            {
                case ItemBase.ItemCategoria.Arma:
                    {
                        armas.Add(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Comestible:
                    {
                        AgregoComestible(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Objeto:
                    {
                        objetos.Add(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Pocion:
                    {
                        if (pociones.Count <= 0)
                        {
                            AgregoPosion(item);
                        }
                        
                        break;
                    }
            }
        }

        // Funcion Quitar un Item
        public void QuitarItem(InventarioItem item)
        {
            switch (item.Categoria)
            {
                case ItemBase.ItemCategoria.Arma:
                    {
                        armas.Remove(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Comestible:
                    {
                        comestibles.Remove(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Objeto:
                    {
                        AgregoObjeto(item);
                        break;
                    }

                case ItemBase.ItemCategoria.Pocion:
                    {
                        pociones.Remove(item);
                        break;
                    }
            }
        }

    public void AgregoComestible(InventarioItem item)
    {
        bool find = false;

        if (comestibles.Count == 0)
        {
            comestibles.Add(item);
        }
        else
        {
            for (int i =0; i < comestibles.Count; i++)
            {
                if (comestibles[i].Nombre == item.Nombre)
                {
                    comestibles[i].Cantidad = comestibles[i].Cantidad + 1;
                    find = true;
                }
            }
            if (!find)
            {
                comestibles.Add(item);
            }
        }
    }

    public void AgregoPosion(InventarioItem item)
    {
        bool find = false;

        if (pociones.Count == 0)
        {
            pociones.Add(item);
        }
        else
        {
            for (int i = 0; i < pociones.Count; i++)
            {
                if (pociones[i].Nombre == item.Nombre)
                {
                    pociones[i].Cantidad = pociones[i].Cantidad + 1;
                    find = true;
                }
            }
            if (!find)
            {
                pociones.Add(item);
            }
        }
    }

    public void AgregoObjeto(InventarioItem item)
    {
        bool find = false;

        if (objetos.Count == 0)
        {
            objetos.Add(item);
        }
        else
        {
            for (int i = 0; i < objetos.Count; i++)
            {
                Debug.Log(i);
                if (objetos[i].Nombre == item.Nombre)
                {
                    objetos[i].Cantidad = objetos[i].Cantidad + 1;
                    find = true;
                }
            }
            if (!find)
            {
                objetos.Add(item);
            }
        }
    }

    public void MuestroInventario()
    {

         string art;
        todo.Clear();

        if (objetos.Count != 0)
        {
            for (int i = 0; i < objetos.Count; i++)
            {
                art =objetos[i].Nombre + "\t\t\t\t" + "Cantidad: " + objetos[i].Cantidad; ;
                todo.Add(art);
            }
        }

        if (pociones.Count != 0)
        {
            for (int i = 0; i < pociones.Count; i++)
            {
                art = pociones[i].Nombre + "\t\t\t\t" + "Cantidad: " + pociones[i].Cantidad; ;
                todo.Add(art);
            }
        }

        if (comestibles.Count != 0)
        {
            for (int i = 0; i < comestibles.Count; i++)
            {
                art = comestibles[i].Nombre + "\t\t\t\t" +  "Cantidad: " + comestibles[i].Cantidad;
                todo.Add(art);
            }
        }

    }

}



