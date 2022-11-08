using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InspectorPedidoDescripcion : PedidosDescripcion
{
    [SerializeField] private Text pedidosRecompensa;

    public override void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        base.ConfigurarPedidosUI(pedidoPorCargar);


        pedidosRecompensa.text = $"{pedidoPorCargar.DescripcionProducto1}" +
                                        $"\n {pedidoPorCargar.CantidadProductoActual1} / {pedidoPorCargar.CantidadProducto1}";
        pedidosRecompensa.text = $"{pedidoPorCargar.DescripcionProducto2}" +
                                     $"\n {pedidoPorCargar.CantidadProductoActual2} / {pedidoPorCargar.CantidadProducto2}";

        pedidosRecompensa.text = $"{pedidoPorCargar.DineroPorVenta}";
    }
}
