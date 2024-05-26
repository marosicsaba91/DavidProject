using UnityEngine;

public class Poolable : MonoBehaviour
{
    public string poolID;

    void OnValidate()
    {
        if (poolID == null || poolID.Length == 0)
            poolID = name;
    }
}
