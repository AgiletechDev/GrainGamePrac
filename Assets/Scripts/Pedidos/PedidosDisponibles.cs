using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]

public class PedidosDisponibles : ScriptableObject
{
    public static Action<PedidosDisponibles> EventoPedidoCompletado;

    public string PedidoNombre;
    public string ID;

    [Header("Producto 1")]
    public InventarioItem Item1;
    public int CantidadProducto1;
    public string DescripcionProducto1;


    [Header("Producto 2")]
    public InventarioItem Item2;
    public int CantidadProducto2;
    public string DescripcionProducto2;


    [Header("Dinero por venta")]
    public int DineroPorVenta;

    //[HideInInspector]
    public int CantidadProductoActual1;
    public int CantidadProductoActual2;
    public bool PedidoCompletadoCheck;

    public void AñadirProgreso(int cantidad)
    {
        CantidadProductoActual1 += cantidad;
        CantidadProductoActual2 += cantidad;
        VerificarPedidoCompletado();
    }

    private void VerificarPedidoCompletado()
    {
        if (CantidadProductoActual1 >= CantidadProducto1 && CantidadProductoActual2 >= CantidadProducto2)
        {
            CantidadProductoActual1 = CantidadProducto1;
            CantidadProductoActual2 = CantidadProducto2;
            PedidoCompletado();
        }

    }

    private void PedidoCompletado()
    {
        if (PedidoCompletadoCheck)
        {
            return;
        }

        PedidoCompletadoCheck = true;
        EventoPedidoCompletado?.Invoke(this);

    }


}