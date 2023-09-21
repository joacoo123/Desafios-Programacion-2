using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
   
    [Header("Configuracion")]
    [SerializeField] private float distanciaMovimiento = 5f;
    [SerializeField] private float velocidadMovimiento = 2f;
    [SerializeField] private bool X;
    [SerializeField] private bool Y;

    private Vector2 initialPosition;
    private SpriteRenderer miSprite;


    private void OnEnable()
    {
        miSprite = GetComponent<SpriteRenderer>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (X)
        {
            float pingPongValue = Mathf.PingPong(Time.time * velocidadMovimiento, distanciaMovimiento);
            Vector2 newPosition = initialPosition + Vector2.right * pingPongValue;
            transform.position = newPosition;

      
        } 
        if(Y)
        {
            float pingPongValue = Mathf.PingPong(Time.time * velocidadMovimiento, distanciaMovimiento);
            Vector2 newPosition = initialPosition + Vector2.up * pingPongValue;
            transform.position = newPosition;
        }
    }
}