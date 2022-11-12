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

    public InventarioItem CopiarItem()
    {
        InventarioItem nuevaInstancia = Instantiate(this);
        return nuevaInstancia;
    }

    /*public virtual bool UsarItem()
    {
        return true;
    }

    public virtual bool EquiparItem()
    {
        return true;
    }*/

    public virtual bool RemoverItem()
    {
        return true;
    }
}
