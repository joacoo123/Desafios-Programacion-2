using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saltar : MonoBehaviour
{

    // Variables a configurar desde el editor
    [Header("Configuracion")]
    private Jugador misDatos;


    // Variables de uso interno en el script
    private bool puedoSaltar = true;
    private bool saltando = false;
    private Vector2 direccion;
    private float ultimaDireccion = 1; // 1 para derecha, -1 para izquierda
    private float axisHorizontal;
    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private AudioSource miAudioSource;
    
    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miAudioSource = GetComponent<AudioSource>();
        misDatos = GetComponent<Jugador>();
     
        
    }

    // Codigo ejecutado en cada frame del juego (Intervalo variable)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && puedoSaltar)
        {
            axisHorizontal = Input.GetAxis("Horizontal");
            direccion = new Vector2(axisHorizontal, 0f);
            puedoSaltar = false;
            if (misDatos.perfilJugador.sonidoSalto)
            {
                if (miAudioSource.isPlaying) { return; }
                ultimaDireccion = Mathf.Sign(direccion.x);
                miAudioSource.PlayOneShot(ultimaDireccion == 1 ? misDatos.perfilJugador.jumpAud : misDatos.perfilJugador.jumpAud2);
            }
           
 

        }
        int velocidadY = (int)miRigidbody2D.velocity.y;
        miAnimator.SetInteger("VelocidadY", velocidadY);
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
        if (collision.gameObject.CompareTag("Plataformas") || collision.gameObject.CompareTag("Piso"))
        {
            puedoSaltar = true;
            saltando = false;
            if (misDatos.perfilJugador.sonidoColision)
            {
                if (miAudioSource.isPlaying) { return; }
                miAudioSource.PlayOneShot(misDatos.perfilJugador.collisionAud);
            }
           
        }
    }


}