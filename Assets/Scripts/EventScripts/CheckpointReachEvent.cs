using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckpointReachEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent _reached;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _pressedColor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerController>(out PlayerController player))
        {
            _reached?.Invoke();
            _spriteRenderer.color = _pressedColor;
        }
    }
}
