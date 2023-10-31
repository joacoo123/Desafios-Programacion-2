using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EditByTime : MonoBehaviour
{

    [Header("Configuracion")]
    [SerializeField] private Color asignarColor;
    [SerializeField] private float duracionActualColor;
    [SerializeField] private float duracionColorAsignado;

    private Color actualColor;
    
    private SpriteRenderer miSpriteRenderer;
    //private Tilemap miTileMap;
    private float tiempoTranscurrido;
    // Start is called before the first frame update
    void OnEnable()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
        //miTileMap = GetComponent<Tilemap>();
       
    }

    void Start()
    {
        tiempoTranscurrido = 0f;
        if (miSpriteRenderer != null)
        {
            actualColor = miSpriteRenderer.color;
        }
        //else if (miTileMap != null)
        //{
        //    actualColor = miTileMap.color;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        asignarColor = new Color(asignarColor.r, asignarColor.g, asignarColor.b, 255);
        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= duracionActualColor)
        {
            if (miSpriteRenderer != null)
            {
                miSpriteRenderer.color = asignarColor;
                if (tiempoTranscurrido >= duracionActualColor + duracionColorAsignado)
                {
                    miSpriteRenderer.color = actualColor;
                    tiempoTranscurrido = 0f;
                }
            }
            //else if (miTileMap != null)
            //{
            //    miTileMap.color = asignarColor;
            //    if (tiempoTranscurrido >= duracionActualColor + duracionColorAsignado)
            //    {
            //        miTileMap.color = actualColor;
            //        tiempoTranscurrido = 0f;
            //    }
            //}
        }
    }
}
