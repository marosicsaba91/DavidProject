using UnityEngine;

public class ResetRigidbody : MonoBehaviour, IPoolable
{
    [SerializeField] Rigidbody rb;

    public void ResetPoolable()
    {
        rb.velocity = Vector3.zero;
    }

    void OnValidate()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }
}
