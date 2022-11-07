using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTienda : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private Image icono;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemCosto;
    [SerializeField] private TextMeshProUGUI cantidadCompra;

    public ItemEnVenta ItemCargado { get; private set; }

    private int cantidad;
    private int costoInicial;
    private int costoActual;

    public void ConfigurarItemEnVenta(ItemEnVenta item)
    {
        ItemCargado = item;
        icono.sprite = item.item.Icono;
        itemName.text = item.item.Nombre;
        itemCosto.text = item.costo.ToString();
        cantidad = 1;
        costoInicial = item.costo;
        costoActual = item.costo;
    }

    private void Update()
    {
        cantidadCompra.text = cantidad.ToString();
        itemCosto.text = costoActual.ToString();
    }

    public void ComprarItem()
    {
        if (MonedasManager.Instance.MonedasTotales >= costoActual)
        {
            /*Inventario.Instance.AñadirItem(ItemCargado.item, cantidad);*/
            MonedasManager.Instance.RemoverMonedas(costoActual);
            cantidad = 1;
            costoActual = costoInicial;
        }
    }

    public void AumentarCantidad()
    {
        int costoDeCompra = costoInicial * (cantidad + 1);
        if (MonedasManager.Instance.MonedasTotales >= costoDeCompra)
        {
            cantidad++;
            costoActual = costoInicial * cantidad;
        }
    }

    public void DisminuirCantidad()
    {
        if (cantidad == 1) return;

        cantidad--;
        costoActual = costoInicial * cantidad;
    }
}
