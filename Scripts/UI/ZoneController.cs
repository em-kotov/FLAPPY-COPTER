using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneController : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _background;
    [SerializeField] private StarSpawner _starSpawner;

    public void SetBackgroundPosition(float offset)
    {
        Vector3 newPosition = _background.position;
        newPosition.x += offset;
        _background.position = newPosition;
    }

    public void SpawnStars()
    {
        _starSpawner.Spawn();
    }

    public void Reset()
    {
        _starSpawner.ClearStars();
    }
}
