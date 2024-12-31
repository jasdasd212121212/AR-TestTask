using UnityEngine;

public class GenericFactory<TObject> where TObject : Object
{
    private TObject _prefab;
    private Transform _parent;

    public GenericFactory() { }

    public GenericFactory(TObject prefab)
    {
        _prefab = prefab;
    }

    public GenericFactory(Transform parent)
    {
        _parent = parent;
    }

    public GenericFactory(TObject prefab, Transform parent)
    {
        _prefab = prefab;
        _parent = parent;
    }

    public TObject Create()
    {
        if (_parent == null || _prefab == null)
        {
            Debug.LogError($"Invalid data -> Parent: {_parent}, Prefab: {_prefab}");
            return default;
        }

        return Create(_prefab, _parent);
    }
    
    public TObject Create(TObject prefab)
    {
        if (_parent == null)
        {
            Debug.LogError($"Invalid data -> Parent: {_parent}");
            return default;
        }

        return Create(prefab, _parent);
    }

    public TObject Create(TObject prefab, Vector3 position)
    {
        return GameObject.Instantiate(prefab, position, Quaternion.identity);
    }

    public TObject Create(TObject prefab, Transform parent)
    {
        return GameObject.Instantiate(prefab, parent);
    }
}