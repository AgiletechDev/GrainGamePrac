using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaciones : MonoBehaviour
{
    [SerializeField] private string layerIdle;
    [SerializeField] private string layerCaminar;

    private Animator _animator;
    private PlayerMovement _personajeMovimiento;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _personajeMovimiento = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        ActualizarLayers();

        if (_personajeMovimiento.EnMovimiento == false)
        {
            return;
        }

         _animator.SetFloat("X", _personajeMovimiento.DireccionMovimiento.x);
         _animator.SetFloat("Y", _personajeMovimiento.DireccionMovimiento.y);
    }

    private void ActivarLayer(string nombreLayer)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }

        _animator.SetLayerWeight(_animator.GetLayerIndex(nombreLayer), 1);
    }

    private void ActualizarLayers()
    {
        if (_personajeMovimiento.EnMovimiento)
        {
            ActivarLayer(layerCaminar);
        }
        else
        {
            ActivarLayer(layerIdle);
        }
    }

}
