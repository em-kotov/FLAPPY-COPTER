using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class CollisionRegister : MonoBehaviour
{
    public event Action PipeFound;
    public event Action<Star> StarFound;
    public event Action<ZoneController> NextZoneControllerFound;

    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out IInteractable interactable))
        {
            if (interactable is Pipe)
                PipeFound?.Invoke();

            if (interactable is Star)
                StarFound?.Invoke(interactable as Star);

            if (interactable is ZoneController)
                NextZoneControllerFound?.Invoke(interactable as ZoneController);
        }
    }
}
