using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosUI : MonoBehaviour
{
    [SerializeField] private PedidoVacio PedidoVacioPrefab;
    [SerializeField] private Transform contenedorPedidos;


    private List<PedidoVacio> pedidoVacioDisponible = new List<PedidoVacio>();

    private void Start()
    {
        PanelPedidos();
    }

    private void PanelPedidos()
    {
        for (int i = 0; i < Pedidos.Instance.NumeroPedidos; i++)
        {
            {
                PedidoVacio nuevoPedidoVacio = Instantiate(PedidoVacioPrefab, contenedorPedidos);
                nuevoPedidoVacio.Index = i;
                pedidoVacioDisponible.Add(nuevoPedidoVacio);
            }
        }
    }


}
