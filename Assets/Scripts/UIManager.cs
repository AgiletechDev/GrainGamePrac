using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject panelInventario;

    [SerializeField] private GameObject panelTienda;

    [SerializeField] private GameObject panelTaller;

    [SerializeField] private GameObject panelPedidos;

    [SerializeField] private Text monedasActuales;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivarPanelPedidos();
        }

        monedasActuales.text = MonedasManager.Instance.MonedasTotales.ToString();
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

    public void AbrirCerrarPanelTienda()
    {
        panelTienda.SetActive(!panelTienda.activeSelf);
    }

    public void AbrirCerrarPanelTaller()
    {
        panelTaller.SetActive(!panelTaller.activeSelf);
    }
}
