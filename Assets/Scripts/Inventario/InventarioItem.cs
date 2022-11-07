using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventarioItem : ScriptableObject
{
    [Header("Parametros")]
    public string ID;
    public string Nombre;
    public Sprite Icono;
    [TextArea] public string Descripcion;

    [Header("Informacion")]
    public bool EsAcumulable;
    public int AcumulacionMax;

    [HideInInspector] public int Cantidad;
}
