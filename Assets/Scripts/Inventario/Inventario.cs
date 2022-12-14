using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : Singleton<Inventario>
{
    [SerializeField] private int numeroDeSlots;
    public int NumeroDeSlots => numeroDeSlots;

    [Header("Items")]
    [SerializeField] private InventarioItem[] itemsInventario;
    public InventarioItem[] ItemsInventario => itemsInventario;

    private void Start()
    {
        itemsInventario = new InventarioItem[numeroDeSlots];
    }

    public void AņadirItem(InventarioItem itemPorAņadir, int cantidad)
    {
        if (itemPorAņadir == null)
        {
            return;
        }

        //Verificar en caso tener ya un item similar en inventario.
        List<int> indexes = VerificarExistencias(itemPorAņadir.ID);
        if (itemPorAņadir.EsAcumulable)
        {
            if (indexes.Count > 0)
            {
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (itemsInventario[indexes[i]].Cantidad < itemPorAņadir.AcumulacionMax)
                    {
                        itemsInventario[indexes[i]].Cantidad += cantidad;
                        if (itemsInventario[indexes[i]].Cantidad > itemPorAņadir.AcumulacionMax)
                        {
                            int diferencia = itemsInventario[indexes[i]].Cantidad - itemPorAņadir.AcumulacionMax;
                            itemsInventario[indexes[i]].Cantidad = itemPorAņadir.AcumulacionMax;
                            AņadirItem(itemPorAņadir, diferencia);
                        }

                        InventarioUI.Instance.DibujarItemEnInventario(itemPorAņadir,
                            itemsInventario[indexes[i]].Cantidad, indexes[i]);
                        return;
                    }
                }
            }
        }

        if (cantidad <= 0)
        {
            return;
        }

        if (cantidad > itemPorAņadir.AcumulacionMax)
        {
            AņadirItemsEnSlotDisponible(itemPorAņadir, itemPorAņadir.AcumulacionMax);
            cantidad -= itemPorAņadir.AcumulacionMax;
            AņadirItem(itemPorAņadir, cantidad);
        }
        else
        {
            AņadirItemsEnSlotDisponible(itemPorAņadir, cantidad);
        }
    }

    private List<int> VerificarExistencias(string itemID)
    {
        List<int> indexesDelItem = new List<int>();
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] != null)
            {
                if (itemsInventario[i].ID == itemID)
                {
                    indexesDelItem.Add(i);
                }
            }

        }

        return indexesDelItem;
    }

    private void AņadirItemsEnSlotDisponible(InventarioItem item, int cantidad)
    {
        for (int i = 0; i < itemsInventario.Length; i++)
        {
            if (itemsInventario[i] == null)
            {
                itemsInventario[i] = item.CopiarItem();
                itemsInventario[i].Cantidad = cantidad;
                InventarioUI.Instance.DibujarItemEnInventario(item, cantidad, i);
                return;
            }
        }
    }

    public void MoverItem(int indexInicial, int indexFinal)
    {
        if (itemsInventario[indexInicial] == null || itemsInventario[indexFinal] != null)
        {
            return;
        }

        //Copiar item en slot final
        InventarioItem itemPorMover = itemsInventario[indexInicial].CopiarItem();
        itemsInventario[indexFinal] = itemPorMover;
        InventarioUI.Instance.DibujarItemEnInventario(itemPorMover, itemPorMover.Cantidad, indexFinal);

        //Borramos Item de Slot Inicial
        itemsInventario[indexInicial] = null;
        InventarioUI.Instance.DibujarItemEnInventario(null, 0, indexInicial);
    }

    /*private void SlotInteraccionRespuesta(TipoDeInteraccion tipo,int index)
    {
        switch (tipo)
        {
            case TipoDeInteraccion.Remover:
                break;
        }
    }*/

    private void EliminarItem(int index)
    {
        ItemsInventario[index].Cantidad--;
        if (itemsInventario[index].Cantidad <= 0)
        {
            itemsInventario[index].Cantidad = 0;
            itemsInventario[index] = null;
            InventarioUI.Instance.DibujarItemEnInventario(null, 0, index);
        }
        else
        {
            InventarioUI.Instance.DibujarItemEnInventario(itemsInventario[index],
                itemsInventario[index].Cantidad, index);
        }
    }

    private void RemoverItem(int index)
    {
        if (itemsInventario[index] == null)
        {
            return;
        }

        itemsInventario[index].RemoverItem();
    }

    public void ConsumirItem(string itemID)
    {
        List<int> indexes = VerificarExistencias(itemID);
        if (indexes.Count > 0)
        {
            EliminarItem(indexes[indexes.Count - 1]);
        }
    }

    public int ObtenerCantidadDeItems(string itemID)
    {
        List<int> indexes = VerificarExistencias(itemID);
        int cantidadTotal = 0;
        foreach (int index in indexes)
        {
            if (itemsInventario[index].ID == itemID)
            {
                cantidadTotal += itemsInventario[index].Cantidad;
            }
        }

        return cantidadTotal;
    }
}
