using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Mover : MonoBehaviour
{

    private Jugador misDatos;
    public bool tocandoPlataforma;
    private float moverHorizontal;
    private Vector2 direccion;
    private Rigidbody2D miRigidbody2D;

    private ControladorAnimacion controladorAnimacion; // Agregar referencia al ControladorAnimacion
    private DeteccionContacto deteccionContacto; // Agregar referencia al DeteccionContacto


    private Vector2 initialPos;
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        controladorAnimacion = GetComponent<ControladorAnimacion>(); // Obtener referencia al ControladorAnimacion
        deteccionContacto = GetComponent<DeteccionContacto>(); // Obtener referencia al DeteccionContacto
        misDatos = GetComponent<Jugador>();
    }

    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);
        initialPos = transform.position;
        controladorAnimacion.ActualizarAnimacion((int)miRigidbody2D.velocity.x, (int)miRigidbody2D.velocity.y, !deteccionContacto.EnContactoConPlataforma());
    }

    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * misDatos.perfilJugador.velocidad);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.parent = collision.transform;
            tocandoPlataforma = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlataformaMovil"))
        {
            transform.parent = null;
            tocandoPlataforma = false;
        }
        transform.position = initialPos;
    }
}