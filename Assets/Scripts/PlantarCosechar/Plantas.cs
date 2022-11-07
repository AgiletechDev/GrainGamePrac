using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Plantas : ScriptableObject
{
    public string nombrePlanta;
    public Sprite[] EstadoPlantas;
    public float tiempoEntreEstados;
}
