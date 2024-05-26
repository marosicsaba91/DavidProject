using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public interface IPoolable
{
    void ResetPoolable();
}


public static class Pool 
{
    static Dictionary<string, List<GameObject>> objectLists = new();


    static public GameObject Pop(Poolable poolable)
    {
        List<GameObject> list = GetPoolList(poolable);

        if (list.Count > 0)
        {
            GameObject go = list[0];
            list.RemoveAt(0);
            go.SetActive(true);
            ResetPoolable(go);
            return go;
        }
        else
        {
            GameObject newGo = Object.Instantiate(poolable.gameObject);
            return newGo;
        }
    }

    static List<GameObject> GetPoolList(Poolable poolable)
    {
        string id = poolable.poolID;

        List<GameObject> list;
        if (objectLists.ContainsKey(id))
        {
            list = objectLists[id];
        }
        else
        {
            list = new();
            objectLists.Add(id, list);
        }

        return list;
    }

    public static void Push(Poolable poolable)
    {
        List<GameObject> list = GetPoolList(poolable);
        poolable.gameObject.SetActive(false);
        list.Add(poolable.gameObject);
    }

    static void ResetPoolable(GameObject obj)
    {
        IPoolable[] poolables = obj.GetComponents<IPoolable>();
        foreach (IPoolable item in poolables)
        {
            item.ResetPoolable();
        }
    }
}
