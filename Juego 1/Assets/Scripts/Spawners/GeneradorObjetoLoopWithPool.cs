using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorObjetoLoopWithPool : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 5f)]

    private float tiempoEspera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoIntervalo;
    
    private ObjectPool objectPool;

    private void Awake()
    {
        objectPool = GetComponent<ObjectPool>(); 
    }

    void Start()
    {
     InvokeRepeating(nameof(GenerarObjetoLoop), tiempoEspera, tiempoIntervalo);
    }



    void GenerarObjetoLoop()
    {
        GameObject pooledObject = objectPool.getPooledObject();
        if(pooledObject != null)
        {
            pooledObject.transform.position = transform.position;
            pooledObject.SetActive(true);
        }
    }
}