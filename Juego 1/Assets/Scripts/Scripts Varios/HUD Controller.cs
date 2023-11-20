using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI miTexto1;
    [SerializeField] TextMeshProUGUI miTexto2;

    [SerializeField] GameObject iconoVida;
    [SerializeField] GameObject contenedorIconosVida;

    public void ActualizarTextoHUD(string nuevoTexto)
    {
        
        miTexto1.text = nuevoTexto;
    }

    public void ActualizarTiempoHUD(string nuevoTiempo)
    {
        miTexto2.text = nuevoTiempo;
    }

    public void ActualizarVidasHUD(int vidas)
    {
        //Debug.Log("ESTAS ACTUALIZANDO VIDAS");
        if (EstaVacioContenedor())
        {
            CargarContenedor(vidas);
            return;
        }

        if (CantidadIconosVidas() > vidas)
        {
            EliminarUltimoIcono();
        }
        else
        {
            CrearIcono();
        }
    }

    private bool EstaVacioContenedor()
    {
        return contenedorIconosVida.transform.childCount == 0;
    }

    private int CantidadIconosVidas()
    {
        return contenedorIconosVida.transform.childCount;
    }

    private void EliminarUltimoIcono()
    {
        Transform contenedor = contenedorIconosVida.transform;
        GameObject.Destroy(contenedor.GetChild(contenedor.childCount - 1).gameObject);
    }

    private void CargarContenedor(int cantidadIconos)
    {
        for (int i = 0; i < cantidadIconos; i++)
        {
            CrearIcono();
        }
    }

    private void CrearIcono()
    {
        Instantiate(iconoVida, contenedorIconosVida.transform);
    }
}