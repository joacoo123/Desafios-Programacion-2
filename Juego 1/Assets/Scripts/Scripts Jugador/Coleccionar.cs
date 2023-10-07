using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionar : MonoBehaviour
{
    [SerializeField] private List<GameObject> colleccionables;
    [SerializeField] GameObject bolsa;

    private bool presionado = false;
   
    private void Awake()
    {
        colleccionables = new List<GameObject>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Coleccionable")) { return; }
        GameObject newColleccionable = collision.gameObject;
        newColleccionable.SetActive(false);
        colleccionables.Add(newColleccionable);
        newColleccionable.transform.SetParent(bolsa.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (colleccionables.Count == 0) return;
            presionado =!presionado;
            colleccionables[0].SetActive(presionado);
        }
    }
}
