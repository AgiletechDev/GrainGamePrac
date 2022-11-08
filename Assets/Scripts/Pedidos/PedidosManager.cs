using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedidosManager : MonoBehaviour
{
    [Header("Pedidos")]
    [SerializeField] private PedidosDisponibles[] pedidosDisponibles;

    [Header("Inspector Pedidos")]
    [SerializeField] private InspectorPedidoDescripcion inspectorPedidoPrefab;
    [SerializeField] private Transform contenedorPedidos;


    public PedidosDisponibles PedidoPorReclamar { get; private set; }

    private void Start()
    {
        CargarPedidoEnInspector();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            AñadirProgreso("Pedido1", 1);
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            ReclamarRecompensa();
        }
    }

    private void CargarPedidoEnInspector()

    {
        for (int i = 0; i < pedidosDisponibles.Length; i++)
        {
            InspectorPedidoDescripcion nuevoPedido = Instantiate(inspectorPedidoPrefab, contenedorPedidos);
            nuevoPedido.ConfigurarPedidosUI(pedidosDisponibles[i]);
        }
    }

    public void AñadirProgreso(string pedidoID, int cantidad)
    {
        PedidosDisponibles pedidoPorActualizar = PedidoExiste(pedidoID);
        pedidoPorActualizar.AñadirProgreso(cantidad);
    }

    private PedidosDisponibles PedidoExiste(string pedidoID)
    {
        for (int i = 0; i < pedidosDisponibles.Length; i++)
        {
            if (pedidosDisponibles[i].ID == pedidoID)
            {
                return pedidosDisponibles[i];
            }
        }

        return null;
    }

    public void ReclamarRecompensa()
    {

        if (PedidoPorReclamar == null)
        {
            return;
        }

        if (PedidoPorReclamar.PedidoCompletadoCheck == true)
        {

            MonedasManager.Instance.AñadirMonedas(PedidoPorReclamar.DineroPorVenta);
            PedidoPorReclamar = null;

        }

    }
}
