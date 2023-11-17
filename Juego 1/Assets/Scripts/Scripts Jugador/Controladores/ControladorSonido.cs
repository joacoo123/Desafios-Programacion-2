using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorSonido : MonoBehaviour
{
    private Jugador misDatos;
    private AudioSource miAudioSource;

    // Start is called before the first frame update
    private void OnEnable()
    {
        misDatos = GetComponent<Jugador>();
        miAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void ActualizarSonido(float ultimaDireccion)
    {
        if (misDatos.perfilJugador.sonidoSalto)
        {
            //if (miAudioSource.isPlaying) { return; }
            miAudioSource.PlayOneShot(ultimaDireccion == 1 ? misDatos.perfilJugador.jumpAud : misDatos.perfilJugador.jumpAud2);
        }
    }
}
