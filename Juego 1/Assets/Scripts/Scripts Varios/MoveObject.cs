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

    //[Header("Otras Caracteristicas")]
    //[SerializeField] private bool estadoModificado;
    //[SerializeField] private float velocidadModificada;

    private Vector2 initialPosition;
    private SpriteRenderer miSprite;
    //private EnemyState enemyState;

    private void OnEnable()
    {
        miSprite = GetComponent<SpriteRenderer>();
        //enemyState = GetComponent<EnemyState>();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (X)
        {
            //if (enemyState.isAngry && estadoModificado)
            //{
            //    velocidadMovimiento = velocidadModificada;
            //} else
            //{
            //    velocidadMovimiento = 2f;
            //}
            float pingPongValue = Mathf.PingPong(Time.time * velocidadMovimiento, distanciaMovimiento);
            Vector2 newPosition = initialPosition + Vector2.right * pingPongValue;
            transform.position = newPosition;

      
        } 
        if(Y)
        {
            //if (enemyState.isAngry && estadoModificado)
            //{
            //    velocidadMovimiento = velocidadModificada;
            //}
            //else
            //{
            //    velocidadMovimiento = 2f;
            //}
            float pingPongValue = Mathf.PingPong(Time.time * velocidadMovimiento, distanciaMovimiento);
            Vector2 newPosition = initialPosition + Vector2.up * pingPongValue;
            transform.position = newPosition;
        }
    }
}