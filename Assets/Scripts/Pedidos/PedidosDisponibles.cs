using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public InventarioItem ProductoIconoItem1;


    [Header("Producto 2")]
    public InventarioItem Item2;
    public int CantidadProducto2;
    public string DescripcionProducto2;
    public InventarioItem ProductoIconoItem2;



    [Header("Dinero por venta")]
    public int DineroPorVenta;

}