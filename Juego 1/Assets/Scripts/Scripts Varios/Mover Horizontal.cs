using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverHorizontal : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;
    [SerializeField] bool Izquierda;
    [SerializeField] bool Derecha;
    private Vector2 direccion;
    private Rigidbody2D miRigidBody2D;
    // Start is called before the first frame update
    private void OnEnable()
    {
        miRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Izquierda) { direccion = new Vector2(-1, 0f); }
        
        else if(Derecha) { direccion = new Vector2(1,0f); }
    }
    void FixedUpdate()
    {

        miRigidBody2D.AddForce(direccion * velocidad);
    }
}
