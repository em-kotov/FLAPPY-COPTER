using UnityEngine;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private Star _starPrefab;
    [SerializeField] private Transform[] _spawnerZones;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private int _count = 3;
    [SerializeField] private float _despawnDistance = 10f;

    private List<Star> _activeStars = new List<Star>();

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            CreateRandomCount(spawnerZone.position);
    }

    public void ClearStars(float playerPositionX)
    {
        float despawnDistance = playerPositionX - _despawnDistance;

        for (int i = 0; i < _activeStars.Count; i++)
        {
            if (_activeStars[i].transform.position.x < despawnDistance)
            {
                Destroy(_activeStars[i].gameObject);
                _activeStars.RemoveAt(i);
            }
            else
            {
                break;
            }
        }
    }

    public void ClearAllStars()
    {
        foreach (Star star in _activeStars)
            Destroy(star.gameObject);

        _activeStars.Clear();
    }

    private void CreateRandomCount(Vector3 position)
    {
        int count = RandomExtensions.GetRandomNumber(1, _count);

        for (int i = 0; i < count; i++)
        {
            Star star = Instantiate(_starPrefab, position, Quaternion.identity);
            star.transform.position = RandomExtensions.GetRandomPosition(position, _radius);
            _activeStars.Add(star);
        }
    }
}
