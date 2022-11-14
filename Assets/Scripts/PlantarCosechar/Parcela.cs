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
    }


    private void OnMouseDown()
    {

        if (SePuedeCosechar == true)
        {
            if (Plantado)
            {

                if (EstadoPlanta == 3)
                {
                    Cosechar();
                    Inventario.Instance.AñadirItem(PlantaSeleccionada.productoItem, PlantaSeleccionada.cantidadCosecha);
                }
            }
        }
        
        else if (SePuedePlantar == true)
        {
            Plantar();
            Inventario.Instance.ConsumirItem(PlantaSeleccionada.productoItem.ID);
        }

    }

    private void Cosechar()
    {
            Plantado = false;
            plantar.gameObject.SetActive(false);

    }

    private void Plantar()
    {
        if (Inventario.Instance.ObtenerCantidadDeItems(PlantaSeleccionada.productoItem.ID) > 0)

        {
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

    public void sePuedePlantar()
    {
        SePuedePlantar = false;
        SePuedeCosechar = true;
    }

    public void sePuedeCosechar()
    {
        SePuedePlantar = true;
        SePuedeCosechar = false;
    }

}
