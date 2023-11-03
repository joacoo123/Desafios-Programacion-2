using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ControladorAnimacion : MonoBehaviour
{
    private Animator miAnimator;
    private SpriteRenderer miSprite;
    private Vector2 direccionSprite;
    private int ultimaDireccion;
    private float getAxis;

    private void Start()
    {
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent <SpriteRenderer>();
    }

    public void ActualizarAnimacion(int velocidadX, bool enAire)
    {
        miAnimator.SetInteger("VelocidadX", velocidadX);
        miAnimator.SetBool("EnAire", enAire);
        //Logica para voltear sprite
        getAxis = Input.GetAxis("Horizontal");
        direccionSprite = new Vector2(getAxis, 0f);

        if (direccionSprite.x > 0)
        {
            ultimaDireccion = 1;
        }
        else if (direccionSprite.x < 0)
        {
            ultimaDireccion = -1;
        }
        miSprite.flipX = ultimaDireccion == -1;       
    }
}