using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DestroyObject : MonoBehaviour
{
    [SerializeField] float DestroyDelay = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D otherObj)
    {
        if (otherObj.gameObject.tag != "Enemigo")
        {
            Destroy(gameObject, DestroyDelay);
        }
        
    }
}
