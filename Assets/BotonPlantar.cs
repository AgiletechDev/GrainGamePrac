using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPlantar : MonoBehaviour
{
    private Parcela parcela;

    private void Start()
    {
        parcela.SePuedePlantar = false;
    }


    private void Siplantar()
    {
        parcela.SePuedePlantar = true;
   
    }
}
