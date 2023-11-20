using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]



    // Variables de uso interno en el script
    private Jugador misDatos;
    private bool puedoSaltar = true;
    private bool saltando = false;
    private Vector2 direccion;
    private float ultimaDireccion = 1; // 1 para derecha, -1 para izquierda
    private float axisHorizontal;
    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;  
    private ControladorAnimacion controladorAnimacion;
    private DeteccionContacto deteccionContacto;
    private ControladorSonido controladorSonido;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        misDatos = GetComponent<Jugador>();
        controladorAnimacion = GetComponent<ControladorAnimacion>();
        controladorSonido = GetComponent<ControladorSonido>();
        deteccionContacto = GetComponent<DeteccionContacto>();       
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            axisHorizontal = Input.GetAxis("Horizontal");
            direccion = new Vector2(axisHorizontal, 0f);
            puedoSaltar = false;        
            ultimaDireccion = Mathf.Sign(direccion.x);        
            controladorSonido.ActualizarSonido(ultimaDireccion);
        }
    }

    private void FixedUpdate()
    {
        if (!puedoSaltar && !saltando)
        {        
                miRigidbody2D.AddForce(Vector2.up * misDatos.perfilJugador.fuerzaSalto, ForceMode2D.Impulse);         
            saltando = true;
        }
    }
   
    // Codigo ejecutado cuando el jugador colisiona con otro objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataformas") || collision.gameObject.CompareTag("Piso")||collision.gameObject.CompareTag("PlataformaMovil"))
        {
            puedoSaltar = true;
            saltando = false;         
        }
    }
}