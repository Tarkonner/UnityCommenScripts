using UnityEngine;

public class EksampelPool : PoolerBase<MonoBehaviour>
{
    [SerializeField] private MonoBehaviour Prefab;

    //Make the pool easy available
    public static EksampelPool Instance;
    private void Awake() => Instance = this;

    //Make the pool
    private void Start() => InitPool(Prefab);
}
