using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

public class PoolerBase<T> : MonoBehaviour where T : MonoBehaviour
{
    //Original code: https://github.com/Matthew-J-Spencer/Object-Pooler

    private T _prefab;
    private ObjectPool<T> _pool;

    [SerializeField] protected int initialSpawn = 10;
    [SerializeField] protected int maxPool = 100;
    [SerializeField] protected bool collectionChecks = false;

    private ObjectPool<T> Pool
    {
        get
        {
            if (_pool == null) throw new InvalidOperationException("You need to call InitPool before using it.");
            return _pool;
        }
        set => _pool = value;
    }

    protected void InitPool(T prefab)
    {
        _prefab = prefab;
        Pool = new ObjectPool<T>(
            CreateSetup,
            GetSetup,
            ReleaseSetup,
            DestroySetup,
            collectionChecks,
            initialSpawn,
            maxPool);

        List<T> make = new List<T>();
        for (int i = 0; i < initialSpawn; i++)
        {
            var spawn = Pool.Get();
            make.Add(spawn);
        }
        foreach (T spawn in make)
        {
            Pool.Release(spawn);
        }
    }

    #region Overrides
    //protected virtual T CreateSetup() => Instantiate(_prefab);
    protected virtual T CreateSetup()
    {
        var spawn = Instantiate(_prefab);
        spawn.transform.parent = gameObject.transform;
        spawn.gameObject.SetActive(false);
        return spawn;
    }
    protected virtual void GetSetup(T obj) => obj.gameObject.SetActive(true);
    protected virtual void ReleaseSetup(T obj) => obj.gameObject.SetActive(false);
    protected virtual void DestroySetup(T obj) => Destroy(obj);
    #endregion

    #region Getters
    public T Get() => Pool.Get();
    public void Release(T obj) => Pool.Release(obj);
    #endregion
}
