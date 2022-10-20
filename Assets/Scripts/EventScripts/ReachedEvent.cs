using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ReachedEvent: MonoBehaviour
{
    [SerializeField] public UnityEvent _reached;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player)){
            _reached?.Invoke();
        }
    }
}
