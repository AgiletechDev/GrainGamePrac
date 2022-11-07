using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelInventario;

    [SerializeField] private GameObject panelPedidos;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivarPanelPedidos();
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

    public void AbrirCerrarPanelInventario()
    {
        panelInventario.SetActive(!panelInventario.activeSelf);
    }
}
