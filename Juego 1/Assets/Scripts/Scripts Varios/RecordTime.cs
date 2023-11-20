using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class RecordTime : MonoBehaviour
{
    // Start is called before the first frame update
    public float recordTime;
    private float timeReset;

    [SerializeField]
    private float resetTime;

    [SerializeField]
    private UnityEvent<string> OnTextChanged;

    [SerializeField]
    private UnityEvent<string> OnTimeChanged;

    void Start()
    {
        recordTime = 0;
        Debug.Log("Tiempo record " + recordTime);
    }

    // Update is called once per frame
    void Update()
    {
        recordTime = GameManager.Instance.tiempoRecord;
        
        OnTextChanged.Invoke("Tiempo record  " + (recordTime-12.0f));
        timeReset += Time.deltaTime;
        OnTimeChanged.Invoke("Reinicio en: " + (resetTime - timeReset));
        
        if (timeReset> (resetTime-0.05f))
        {
            Debug.Log("Reset");
            SceneManager.LoadScene(0);
        }

    }
}
