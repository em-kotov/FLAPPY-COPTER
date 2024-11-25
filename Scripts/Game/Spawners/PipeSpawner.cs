using UnityEngine;
using System.Collections.Generic;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _pipePrefabs;
    [SerializeField] private Transform[] _spawnerZones;
    [SerializeField] private float _despawnDistance = 10f;

    private List<Transform> _activePipes = new List<Transform>();

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            Create(spawnerZone.position);
    }

    public void ClearPipes(float playerPositionX)
    {
        float despawnDistance = playerPositionX - _despawnDistance;

        for (int i = 0; i < _activePipes.Count; i++)
        {
            if (_activePipes[i].transform.position.x < despawnDistance)
            {
                Destroy(_activePipes[i].gameObject);
                _activePipes.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
    }

    public void ClearAllPipes()
    {
        foreach (Transform pipe in _activePipes)
            Destroy(pipe.gameObject);

        _activePipes.Clear();
    }

    private void Create(Vector3 position)
    {
        Transform pipe = Instantiate(_pipePrefabs[RandomExtensions.GetRandomNumber(
                                0, _pipePrefabs.Length)], position, Quaternion.identity);
        _activePipes.Add(pipe);
    }
}
