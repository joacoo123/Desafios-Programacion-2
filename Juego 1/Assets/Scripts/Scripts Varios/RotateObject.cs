using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private float X;
    [SerializeField] private float Y;
    [SerializeField] private float Z;
    void Start()
    {

    }

    void Update()
    {
        transform.Rotate(new Vector3(X,Y,Z)*Time.deltaTime);
    }
}
