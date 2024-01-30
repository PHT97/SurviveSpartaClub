using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in pools)
        {
            InitPool(pool);
        }
    }

    void InitPool(string tag)
    {
        var pool = pools.Find(p => p.tag == tag);
        InitPool(pool);
    }

    void InitPool(Pool pool)
    {
        Queue<GameObject> objectPool = new Queue<GameObject>();
        for (int i = 0; i < pool.size; i++)
        {
            GameObject obj = Instantiate(pool.prefab);
            obj.SetActive(false);
            objectPool.Enqueue(obj);
        }

        if (poolDictionary.ContainsKey(pool.tag))
        {
            poolDictionary[pool.tag] = objectPool;
        }
        else
        {
            poolDictionary.Add(pool.tag, objectPool);
        }

    }

    public GameObject SpawnFromPool(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
            return null;

        GameObject obj = poolDictionary[tag].Dequeue();

        if (obj == null)
        {
            InitPool(tag);
            obj = poolDictionary[tag].Dequeue();
        }

        poolDictionary[tag].Enqueue(obj);

        return obj;
    }
}