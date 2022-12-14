using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TallerManager : Singleton<TallerManager>
{
    [Header("Config")]
    [SerializeField] private ItemTaller taller1ItemsCrafteo;
    [SerializeField] private ItemTaller taller2ItemsCrafteo;
    [SerializeField] private Transform panelContenedor;
    [SerializeField] private TextMeshProUGUI textoResultado;

    [Header("Recetas")]
    //El "NonReorderable" es para solucionar un bug visual del unity
    [SerializeField] [NonReorderable] private ItemParaCraftear[] itemsDisponibles;

    private void Start()
    {
        CargarItemsCrafteables();
    }

    private void CargarItemsCrafteables()
    {
        for (int i = 0; i < itemsDisponibles.Length; i++)
        {
            if (itemsDisponibles[i].CantidadItems == canItems.UsaUnItem1)
            {
                ItemTaller itemTaller = Instantiate(taller1ItemsCrafteo, panelContenedor);
                itemTaller.ConfigurarItems(itemsDisponibles[i]);
            }
            else
            {
                ItemTaller itemTaller = Instantiate(taller2ItemsCrafteo, panelContenedor);
                itemTaller.ConfigurarItems2(itemsDisponibles[i]);
            }
        }
    }

    public void MensajeResultado(bool sePuedoCraftear, string nombreItem)
    {
        if (sePuedoCraftear)
        {
            textoResultado.text = $"Se creo su {nombreItem} exitosamente";
        }
        else
        {
            textoResultado.text = $"No se pudo crear su {nombreItem}";
        }
    }
}
