using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedidosDescripcion : MonoBehaviour
{

    [SerializeField] private Text pedidoNombre;
    [SerializeField] private Text pedidoDescripcionProducto1;
    [SerializeField] private Text pedidoDescripcionProducto2;
    [SerializeField] private Text dineroPorVenta;


    public virtual void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        pedidoNombre.text = pedidoPorCargar.PedidoNombre.ToString();
        pedidoDescripcionProducto1.text = pedidoPorCargar.DescripcionProducto1.ToString();
        pedidoDescripcionProducto2.text = pedidoPorCargar.DescripcionProducto2.ToString();
        dineroPorVenta.text = pedidoPorCargar.DineroPorVenta.ToString();
    }
}
