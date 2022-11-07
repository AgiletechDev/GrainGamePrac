using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]

public class PedidosDisponibles : ScriptableObject
{

    public string IDPedido;
    public string PedidoNombre;

    [Header("Producto 1")]
    public int NecesitaManzana;
    public string DescripcionManzana;


    [Header("Producto 2")]
    public int NecesitaPi�a;
    public string DescripcionPi�a;
    

    [Header("Dinero por venta")]
    public int DineroPorVenta;


}