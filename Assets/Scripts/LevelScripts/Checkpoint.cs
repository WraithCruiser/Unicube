using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private ReachedEvent _reached;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _reachedColor;

    private void SaveSpawnPoint()
    {
        PlayerController._spawnPoint = transform.position;
        _spriteRenderer.color = _reachedColor;
    }

    private void OnEnable()
    {
        _reached._reached.AddListener(SaveSpawnPoint);
    }

    private void OnDisable()
    {
        _reached._reached.RemoveListener(SaveSpawnPoint);
    }
}
