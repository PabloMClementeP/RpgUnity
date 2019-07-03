using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAgent : MonoBehaviour
{
    public InventarioItem item;
    GameManager gm;

    private void Awake()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            MisionManager.misionManager.AgregarItem(this.gameObject);

            InventarioItem miItem = new InventarioItem();
            miItem.CopioInventarioItem(item);

            //agrego desde GameMAnager el item al inventario
            gm.Inventario.AgregarItem(item);
            // elimino desde GameManager el gameObject
            gm.RpgDestroy(gameObject);
        }
    }

}
