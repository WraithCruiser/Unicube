using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAction : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void OpenDoor()
    {
        _animator.SetBool("IsOpened", true);
    }
}
