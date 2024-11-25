using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ZoneController : MonoBehaviour, IInteractable
{
    [SerializeField] private Transform _background;
    [SerializeField] private StarSpawner _starSpawner;
    [SerializeField] private PipeSpawner _pipeSpawner;

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

    public void SpawnPipes()
    {
        _pipeSpawner.Spawn();
    }

    public void ClearStars(float copterPositionX)
    {
        _starSpawner.ClearStars(copterPositionX);
    }
    
    public void ClearPipes(float copterPositionX)
    {
        _pipeSpawner.ClearPipes(copterPositionX);
    }

    public void ClearAllObjects()
    {
        _starSpawner.ClearAllStars();
        _pipeSpawner.ClearAllPipes();
    }

    public void ResetPosition(Vector3 position)
    {
        ClearAllObjects();
        _background.position = position;
    }
}
