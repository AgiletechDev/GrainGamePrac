using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Parcela : MonoBehaviour
{
    public bool SePuedePlantar;
    public bool SePuedeCosechar;

    bool Plantado = false;
    public SpriteRenderer plantar;

    int EstadoPlanta = 0;
    float tiempo;

    public Plantas PlantaSeleccionada;

    private void Start()
    {
        plantar = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (SePuedePlantar == true)

        {
            if (Plantado)
            {
                tiempo -= Time.deltaTime;

                if (tiempo < 0 && EstadoPlanta <= PlantaSeleccionada.EstadoPlantas.Length - 1)
                {
                    tiempo = PlantaSeleccionada.tiempoEntreEstados;
                    EstadoPlanta++;
                    ActualizarCultivo();
                }
            }
            
            return;
        }

        if (SePuedeCosechar)
        {
           
        }
        
    }


    private void OnMouseDown()
    {
        if (Plantado)
        {

            if (EstadoPlanta == 3)
            {
                Cosechar();
            }
        }
        else
        {
            Plantar();
        }

    }

    private void Cosechar()
    {
        if (SePuedeCosechar)
        {
            Plantado = false;
            plantar.gameObject.SetActive(false);
        }
    }

    private void Plantar()
    {
        if (SePuedePlantar == true)
        {
            SePuedeCosechar = false;
            Plantado = true;
            EstadoPlanta = 0;
            ActualizarCultivo();
            tiempo = PlantaSeleccionada.tiempoEntreEstados;
            plantar.gameObject.SetActive(true);
        }

    }

    private void ActualizarCultivo()
    {
        plantar.sprite = PlantaSeleccionada.EstadoPlantas[EstadoPlanta];
    }

}
