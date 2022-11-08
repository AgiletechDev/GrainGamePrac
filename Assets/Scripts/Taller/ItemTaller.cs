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

    public ItemParaCraftear ItemCargado { get; private set; }

    public void ConfigurarItems(ItemParaCraftear item)
    {
        ItemCargado = item;
        iconoItemCrafteo.sprite = item.itemACraftear.Icono;
        itemName.text = item.itemACraftear.Nombre;
        itemNecesario1Img.sprite = item.itemNecesario1.Icono;
    }

    public void ConfigurarItems2(ItemParaCraftear item)
    {
        ConfigurarItems(item);
        itemNecesario2Img.sprite = item.itemNecesario2.Icono;
    }
}
