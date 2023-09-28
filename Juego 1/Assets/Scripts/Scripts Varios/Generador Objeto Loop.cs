using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoop : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField]
    [Range(0.5f, 5f)]

    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;

    [SerializeField] private bool DebugVisible;

    void Start()
    {
     
            InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
        
    }

    void GenerarObjetoLoop()
    {
        Instantiate(objetoPrefab, transform.position, Quaternion.identity);
    }

    private void OnBecameInvisible()
    {
        if (DebugVisible)
        {
            Debug.Log("El SpriteRenderer deja de ser visible por las cámaras en la escena");
        }
        CancelInvoke(nameof(GenerarObjetoLoop));
    }

    private void OnBecameVisible()
    {
        if (DebugVisible)
        {
            Debug.Log("El SpriteRenderer es visible por las cámaras en la escena");
        }
        InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }
}