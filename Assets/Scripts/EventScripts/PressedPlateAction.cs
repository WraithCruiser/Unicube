using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedPlateAction : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Color _pressedColor;

    public void Press()
    {
        _spriteRenderer.color = _pressedColor;
    }
}
