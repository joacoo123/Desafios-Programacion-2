using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionContacto : MonoBehaviour
{
    private BoxCollider2D miCollider2d;
    private int saltarMask;

    private void Start()
    {
        miCollider2d = GetComponent<BoxCollider2D>();
        saltarMask = LayerMask.GetMask("Piso", "Plataformas","PlataformaMovil");
    }

    public bool EnContactoConPlataforma()
    {
        return miCollider2d.IsTouchingLayers(saltarMask);
    }
}