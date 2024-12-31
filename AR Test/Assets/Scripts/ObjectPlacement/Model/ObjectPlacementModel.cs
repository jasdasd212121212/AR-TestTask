using System;
using UnityEngine;

public class ObjectPlacementModel : IReadOnlyPlacementModel
{
    private int _currentObject;
    private int _objectsCount;

    public event Action objectChanged;
    public event Action<int, Vector3, Vector3> objectSpawned;

    public ObjectPlacementModel(int objectsCount)
    {
        _objectsCount = Mathf.Clamp(objectsCount, 0, int.MaxValue);
        _currentObject = 0;
    }

    public void SelectObject(int objectIndex)
    {
        if (objectIndex < 0 || objectIndex >= _objectsCount)
        {
            Debug.LogError($"Error -> can`t spawn object by invalid index: {objectIndex} (BOUNDS: 0, {_objectsCount - 1}); In result -> Clamped");
        }

        _currentObject = Mathf.Clamp(_currentObject, 0, _objectsCount - 1);

        _currentObject = objectIndex;
        objectChanged?.Invoke();
    }

    public void SpawnCurrent(Vector3 position, Vector3 normal)
    {
        objectSpawned?.Invoke(_currentObject, position, normal);
    }
}