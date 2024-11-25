using System;
using UnityEngine;

public class Copter : MonoBehaviour
{
    public event Action GameOver;

    public void OnPipeFound()
    {
        GameOver?.Invoke();
    }
}
