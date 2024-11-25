using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private const KeyCode JumpKey = KeyCode.Space;

    public event Action JumpKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed?.Invoke();
    }
}
