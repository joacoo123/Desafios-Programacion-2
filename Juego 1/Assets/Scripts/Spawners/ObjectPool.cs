using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject thePrefab;
    [SerializeField] private int poolSize = 5;

    private List<GameObject> pooledObjects;

    // Start is called before the first frame update
    void Start()
    {
        pooledObjects = new List<GameObject> ();

        for(int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(thePrefab);
            obj.SetActive(false);
            pooledObjects.Add (obj);
        }
    }

    public  GameObject getPooledObject()
    {
        foreach(GameObject obj in pooledObjects)
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        return null;
    }
}
