using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartelPedidosInteraccion : MonoBehaviour
{
    [SerializeField] private GameObject cartelButtonInteractuar;

    [SerializeField] private GameObject panelPedidos;

    private void Update()
    {

        if (cartelButtonInteractuar.activeSelf && Input.GetKeyDown(KeyCode.P))
        {
            ActivarPanelPedidos();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            cartelButtonInteractuar.SetActive(true);
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
         if (other.CompareTag("Player"))
         {
            cartelButtonInteractuar.SetActive(false);
         }
    }

    public void ActivarPanelPedidos()
    {
        panelPedidos.SetActive(true);

    }

    public void CerrarPanelPedidos()
    {
        panelPedidos.SetActive(false);
    }
}
