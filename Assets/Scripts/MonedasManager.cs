using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonedasManager : Singleton<MonedasManager>
{
    [SerializeField] private int monedasTest;
    public int MonedasTotales { get; set; }

    private string Key_Coins = "Coins";

    private void Start()
    {
        PlayerPrefs.DeleteKey(Key_Coins);
        CargarMonedas();
    }

    private void CargarMonedas()
    {
        MonedasTotales = PlayerPrefs.GetInt(Key_Coins, monedasTest);
    }

    public void AñadirMonedas(int cantidad)
    {
        MonedasTotales += cantidad;
        PlayerPrefs.SetInt(Key_Coins, MonedasTotales);
        PlayerPrefs.Save();
    }

    public void RemoverMonedas(int cantidad)
    {
        if (MonedasTotales < cantidad) return;

        MonedasTotales -= cantidad;
        PlayerPrefs.SetInt(Key_Coins, MonedasTotales);
        PlayerPrefs.Save();
    }
}
