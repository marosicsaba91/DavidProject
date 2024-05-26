using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    [SerializeField] Poolable spawnable;

    [SerializeField] float spawnEverySecond = 100;
    [SerializeField] Bounds spawnArea = new Bounds(Vector3.zero, Vector3.one * 10);

    float remainder = 0;

    void Update()
    {
        float spawnCount = (spawnEverySecond * Time.deltaTime) + remainder;
        int count = (int)spawnCount;
        remainder = spawnCount % 1;

        for (int i = 0; i < count; i++)
            Spawn();
    }

    void Spawn()
    {
        Vector3 pos = GetRandomPoint(spawnArea);
        Quaternion rot = GetRandomRotation(); 

        GameObject newGo = Pool.instance.Pop(spawnable);

        newGo.transform.parent = transform;
        newGo.transform.SetPositionAndRotation(pos, rot);
    }

    Quaternion GetRandomRotation()
    {
        float x = Random.Range(0,360);
        float y = Random.Range(0,360);
        float z = Random.Range(0,360);

        return Quaternion.Euler(x,y,z);
    }

    Vector3 GetRandomPoint(Bounds spawnArea)
    {
        float x = Random.Range(spawnArea.min.x, spawnArea.max.x);
        float y = Random.Range(spawnArea.min.y, spawnArea.max.y);
        float z = Random.Range(spawnArea.min.z, spawnArea.max.z);

        return new(x,y,z);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(spawnArea.center, spawnArea.size);
    }
}
