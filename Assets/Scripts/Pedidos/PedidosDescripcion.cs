using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PedidosDescripcion : MonoBehaviour
{

    [SerializeField] private Text pedidoNombre;
    [SerializeField] private Text pedidoDescripcionProducto1;
    [SerializeField] private Text pedidoDescripcionProducto2;
    [SerializeField] private Text dineroPorVenta;
    [SerializeField] private Text cantidadProducto1;
    [SerializeField] private Text cantidadProducto2;


    public virtual void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        pedidoNombre.text = pedidoPorCargar.PedidoNombre.ToString();
        pedidoDescripcionProducto1.text = pedidoPorCargar.DescripcionProducto1.ToString();
        pedidoDescripcionProducto2.text = pedidoPorCargar.DescripcionProducto2.ToString();
        dineroPorVenta.text = pedidoPorCargar.DineroPorVenta.ToString();
        cantidadProducto1.text = pedidoPorCargar.CantidadProducto1.ToString();
        cantidadProducto2.text = pedidoPorCargar.CantidadProducto2.ToString();
    }
}
