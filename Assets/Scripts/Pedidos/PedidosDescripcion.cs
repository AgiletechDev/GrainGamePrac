using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PedidosDescripcion : MonoBehaviour
{
    [SerializeField] private Text pedidoNombre;
    [SerializeField] private Text pedidoDineroPorVenta;
    [SerializeField] private Text pedidoDescripcionManzana;
    [SerializeField] private Text pedidoDescripcionPi�a;

    public virtual void ConfigurarPedidosUI(PedidosDisponibles pedidoPorCargar)
    {
        pedidoNombre.text = pedidoPorCargar.PedidoNombre;
        pedidoDescripcionManzana.text = pedidoPorCargar.DescripcionManzana;
        pedidoDescripcionPi�a.text = pedidoPorCargar.DescripcionPi�a;

        pedidoDescripcionManzana.text = $"{pedidoPorCargar.DescripcionManzana}" +
                                        $"\n {pedidoPorCargar.NecesitaManzana}";
        pedidoDescripcionPi�a.text = $"{pedidoPorCargar.DescripcionPi�a}" +
                                     $"\n {pedidoPorCargar.NecesitaPi�a}";
        pedidoNombre.text = $"{pedidoPorCargar.PedidoNombre}";
        pedidoDineroPorVenta.text = $"{pedidoPorCargar.DineroPorVenta}";

    }

}
