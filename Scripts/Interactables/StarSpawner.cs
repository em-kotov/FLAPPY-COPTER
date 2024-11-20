using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private Star _starPrefab;
    [SerializeField] private Transform[] _spawnerZones;
    [SerializeField] private float _radius = 3f;
    [SerializeField] private int _count = 3;

    private List<Star> _createdStars = new List<Star>();

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        foreach (Transform spawnerZone in _spawnerZones)
            CreateRandomCount(spawnerZone.position);
    }

    public void ClearStars()
    {
        foreach(Star star in _createdStars)
            star.Deactivate();
    }

    private void CreateRandomCount(Vector3 position)
    {
        int count = GetRandomCount();

        for (int i = 0; i < count; i++)
            CreateOne(position);
    }

    private void CreateOne(Vector3 position)
    {
        Star star = Instantiate(_starPrefab, GetRandomPosition(position), Quaternion.identity);
        _createdStars.Add(star);
    }

    private Vector3 GetRandomPosition(Vector3 position)
    {
        Vector3 randomPosition = Random.insideUnitSphere * _radius;
        return randomPosition + position;
    }

    private int GetRandomCount()
    {
        return Random.Range(1, _count + 1);
    }
}
