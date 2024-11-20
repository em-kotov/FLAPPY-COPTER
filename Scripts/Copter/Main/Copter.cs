using System;
using UnityEngine;

public class Copter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private Mover _mover;

    public event Action GameOver;

    public void OnPipeFound()
    {
        GameOver?.Invoke();
    }
    
    public void OnStarFound()
    {
    
    }

    public void Reset()
    {
        _inventory.Reset();
        _mover.Reset();
    }
}
