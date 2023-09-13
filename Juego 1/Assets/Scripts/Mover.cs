using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    // Variables a configurar desde el editor
    [Header("Configuracion")]
    [SerializeField] float velocidad = 5f;

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;
    private int ultimaDireccion = 1; // 1 para derecha, -1 para izquierda
    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private BoxCollider2D miCollider2d;

    private int saltarMask;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        miCollider2d = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Piso","Plataformas");
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        direccion = new Vector2(moverHorizontal, 0f);


        if (direccion.x > 0)
        {
            ultimaDireccion = 1;
        }
        else if (direccion.x < 0)
        {
            ultimaDireccion = -1;
        }

        miSprite.flipX = ultimaDireccion == -1;
        int velocidadX = (int)miRigidbody2D.velocity.x;
        miAnimator.SetInteger("VelocidadX", velocidadX);
        miAnimator.SetBool("EnAire",miRigidbody2D.velocity.y != 0f);
    }
    private void FixedUpdate()
    {
        miRigidbody2D.AddForce(direccion * velocidad);
    }

    private bool EnContactoConPlataforma()
    {
        return miCollider2d.IsTouchingLayers(saltarMask);
    }
}