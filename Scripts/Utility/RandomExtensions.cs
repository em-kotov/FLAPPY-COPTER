using UnityEngine;

public static class RandomExtensions
{
    public static Vector3 GetRandomPositionXZ(Vector3 position, float radius)
    {
        Vector3 randomPositionXZ = Random.insideUnitSphere * radius;
        return new Vector3(randomPositionXZ.x, position.y, randomPositionXZ.z);
    }

    public static Vector3 GetRandomPosition(Vector3 position, float radius)
    {
        Vector3 randomPosition = Random.insideUnitSphere * radius;
        return randomPosition + position;
    }

    public static int GetRandomNumber(int min, int max)
    {
        return Random.Range(min, max);
    }
}