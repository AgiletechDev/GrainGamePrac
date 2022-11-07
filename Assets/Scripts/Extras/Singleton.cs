using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T:Component
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            //Si la instancia es nula, buscamos el objeto del tipo que está siendo heredado.
            if (_instance==null)
            {
                _instance = FindObjectOfType<T>();
                //Si la instancia sigue siendo nula, forzaremos añadir el componente T al nuevo game object.
                if (_instance==null)
                {
                    GameObject nuevoGO = new GameObject();
                    _instance = nuevoGO.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        //La instancia será igual a esta clase pero del tipo T.
        _instance = this as T;
    }

}
