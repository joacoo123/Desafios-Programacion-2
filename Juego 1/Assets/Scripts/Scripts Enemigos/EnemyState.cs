using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    private SpriteRenderer miSpriteRenderer;
    private Color actualColor;
    private Color cambioColor;
    public bool isAngry;


    // Start is called before the first frame update

    void OnEnable()
    {
        miSpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        actualColor = miSpriteRenderer.color;
    }


    // Update is called once per frame
    void Update()
    {
        cambioColor = miSpriteRenderer.color;
        if (cambioColor != actualColor)
        {
            isAngry = true;
        } else
        {
            isAngry = false;
        }
    }
}
