using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedidos : Singleton<Pedidos>
{
    [SerializeField] private int numeroPedidos;
    public int NumeroPedidos => numeroPedidos;

    

}