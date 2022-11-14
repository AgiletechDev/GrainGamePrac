using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InspectorPedidoDescripcion : PedidosDescripcion
{
    [SerializeField] private Text pedidosRecompensa;
    [SerializeField] private Image productoIcono1;
    [SerializeField] private Image productoIcono2;
    [SerializeField] private Text cantidadProductoActual1;
    [SerializeField] private Text cantidadProductoActual2;


    public PedidosDisponibles PedidoPorEntregar { get; private set; }

    public override void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        base.ConfigurarPedidosUI(pedidoPorCargar);

        PedidoPorEntregar = pedidoPorCargar;
        pedidosRecompensa.text = $"{pedidoPorCargar.DescripcionProducto1}";
        pedidosRecompensa.text = $"{pedidoPorCargar.CantidadProducto1}";
        pedidosRecompensa.text = $"{pedidoPorCargar.DescripcionProducto2}"; 
        pedidosRecompensa.text = $"{pedidoPorCargar.CantidadProducto2}";
        pedidosRecompensa.text = $"{pedidoPorCargar.DineroPorVenta}";
        productoIcono1.sprite = pedidoPorCargar.ProductoIconoItem1.Icono;
        productoIcono2.sprite = pedidoPorCargar.ProductoIconoItem2.Icono;
        cantidadProductoActual1.text = $"{Inventario.Instance.ObtenerCantidadDeItems(pedidoPorCargar.Item1.ID)}";
        cantidadProductoActual2.text = $"{Inventario.Instance.ObtenerCantidadDeItems(pedidoPorCargar.Item2.ID)}";




    }


    public void ReclamarRecompensa()
    {
        if (PedidoPorEntregar == null)
        {
            return;

        }


        if (Inventario.Instance.ObtenerCantidadDeItems(PedidoPorEntregar.Item1.ID) >= PedidoPorEntregar.CantidadProducto1
        && Inventario.Instance.ObtenerCantidadDeItems(PedidoPorEntregar.Item2.ID) >= PedidoPorEntregar.CantidadProducto2)

        {
            MonedasManager.Instance.AñadirMonedas(PedidoPorEntregar.DineroPorVenta);
            Inventario.Instance.ConsumirItem(PedidoPorEntregar.Item1.ID);
            Inventario.Instance.ConsumirItem(PedidoPorEntregar.Item2.ID);
            PedidoPorEntregar = null;
            Destroy(this.gameObject);
        }

        return;
        
    }
}
