using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum canItems
{
    UsaUnItem1,
    UsaDosItems2,
}

[Serializable]
public class ItemParaCraftear
{
    [SerializeField] private canItems cantidadItems;
    //Esto para saber el tipo en otros scripts
    public canItems CantidadItems => cantidadItems;

    public InventarioItem itemACraftear;

    [Header("Item1")]
    public InventarioItem itemNecesario1;
    public int cantidadItem1;
    [Header("Item2 (Si no lo usa, dejar vacio)")]
    public InventarioItem itemNecesario2;
    public int cantidadItem2;
}
