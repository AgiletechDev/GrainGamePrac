using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemTaller : MonoBehaviour
{
    [Header("Item a Craftear")]
    [SerializeField] private Image iconoItemCrafteo;
    [SerializeField] private TextMeshProUGUI itemName;

    [Header("Item necesario 1")]
    [SerializeField] private Image itemNecesario1Img;
    [SerializeField] private TextMeshProUGUI cantidadItem1;

    [Header("Item necesario 2(Solo si es necesario)")]
    [SerializeField] private Image itemNecesario2Img;
    [SerializeField] private TextMeshProUGUI cantidadItem2;

    private bool usaDosItems = false;

    public ItemParaCraftear ItemCargado { get; private set; }

    public void ConfigurarItems(ItemParaCraftear item)
    {
        ItemCargado = item;
        iconoItemCrafteo.sprite = item.itemACraftear.Icono;
        itemName.text = item.itemACraftear.Nombre;
        itemNecesario1Img.sprite = item.itemNecesario1.Icono;
        cantidadItem1.text = $"{Inventario.Instance.ObtenerCantidadDeItems(ItemCargado.itemNecesario1.ID)}/{ItemCargado.cantidadItem1}";
    }

    public void ConfigurarItems2(ItemParaCraftear item)
    {
        ConfigurarItems(item);
        itemNecesario2Img.sprite = item.itemNecesario2.Icono;
        cantidadItem2.text = $"{Inventario.Instance.ObtenerCantidadDeItems(ItemCargado.itemNecesario2.ID)}/{ItemCargado.cantidadItem2}";
        usaDosItems = true;
    }

    private bool SePuedeCraftear()
    {
        if (usaDosItems)
        {
            if (Inventario.Instance.ObtenerCantidadDeItems(ItemCargado.itemNecesario1.ID) >= ItemCargado.cantidadItem1 && Inventario.Instance.ObtenerCantidadDeItems(ItemCargado.itemNecesario2.ID) >= ItemCargado.cantidadItem2)
            {
                return true;
            }

        }
        else
        {
            if (Inventario.Instance.ObtenerCantidadDeItems(ItemCargado.itemNecesario1.ID) >= ItemCargado.cantidadItem1)
            {
                return true;
            }
        }
        return false;
    }

    public void Comprar()
    {
        if (SePuedeCraftear() == false)
        {
            TallerManager.Instance.MensajeResultado(false, itemName.text);
            return;
        }

        for (int i = 0; i < ItemCargado.cantidadItem1; i++)
        {
            Inventario.Instance.ConsumirItem(ItemCargado.itemNecesario1.ID);
        }

        if (usaDosItems)
        {
            for (int i = 0; i < ItemCargado.cantidadItem2; i++)
            {
                Inventario.Instance.ConsumirItem(ItemCargado.itemNecesario2.ID);
            }
        }

        Inventario.Instance.AñadirItem(ItemCargado.itemACraftear, 1);
        TallerManager.Instance.MensajeResultado(true, itemName.text);
        Actualizar();
    }

    public void Actualizar()
    {
        if (usaDosItems)
        {
            ConfigurarItems2(ItemCargado);
            return;
        }
        ConfigurarItems(ItemCargado);
    }

    private void OnEnable()
    {
        Actualizar();
    }
}
