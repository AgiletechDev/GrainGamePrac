using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 _input, _direccionMovement;
    [SerializeField] private float velocidad;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //Movimiento
        _direccionMovement.x = (_input.x > 0.1f) ? 1f : (_input.x < -0.1f) ? -1f : 0f;
        _direccionMovement.y = (_input.y > 0.1f) ? 1f : (_input.y < -0.1f) ? -1f : 0f;
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + _direccionMovement * velocidad * Time.fixedDeltaTime);
    }
}
