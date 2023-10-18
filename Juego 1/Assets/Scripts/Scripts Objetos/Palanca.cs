using UnityEngine;
using UnityEngine.Events;

public class Palanca : MonoBehaviour
{
   [SerializeField] private UnityEvent OnPalancaTriggered;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Puerta desactivada");
            OnPalancaTriggered.Invoke();
        }
    }
}