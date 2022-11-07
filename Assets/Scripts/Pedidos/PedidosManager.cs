using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosManager : MonoBehaviour
{
    [Header("Pedidos")]
    [SerializeField] private PedidosDisponibles[] pedidosDisponibles;

    private void Update()
    {
        pedidoEntregado();
    }


    private void pedidoEntregado()
    {

    }


}
