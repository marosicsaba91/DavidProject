using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Poolable p))
            Pool.instance.Push(p);
        else
            Destroy(other.gameObject);
    }
}
