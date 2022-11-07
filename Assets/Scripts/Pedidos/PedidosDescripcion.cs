using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedidosDescripcion : MonoBehaviour
{
    [SerializeField] private Text pedidoNombre;
    [SerializeField] private Text pedidoDineroPorVenta;
    [SerializeField] private Text pedidoDescripcionManzana;
    [SerializeField] private Text pedidoDescripcionPiña;

    public virtual void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        pedidoNombre.text = pedidoPorCargar.PedidoNombre;
        pedidoDescripcionManzana.text = pedidoPorCargar.DescripcionManzana;
        pedidoDescripcionPiña.text = pedidoPorCargar.DescripcionPiña;

        pedidoDescripcionManzana.text = $"{pedidoPorCargar.DescripcionManzana}" +
                                        $"\n {pedidoPorCargar.NecesitaManzana}";
        pedidoDescripcionPiña.text = $"{pedidoPorCargar.DescripcionPiña}" +
                                     $"\n {pedidoPorCargar.NecesitaPiña}";
        pedidoNombre.text = $"{pedidoPorCargar.PedidoNombre}";
        pedidoDineroPorVenta.text = $"{pedidoPorCargar.DineroPorVenta}";

    }

}
