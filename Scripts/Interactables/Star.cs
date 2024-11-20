using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Star : MonoBehaviour, IInteractable
{
    public bool CanCollect { get; private set; } = true;

    public void Deactivate()
    {
        CanCollect = false;
        gameObject.SetActive(false);
    }
}
