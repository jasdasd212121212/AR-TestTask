using UnityEngine;

public class DraggebleObject : BaseInteractebleObject
{
    private Transform _cachedTransform;

    public Transform Transform
    {
        get
        {
            if (_cachedTransform == null)
            {
                _cachedTransform = transform;
            }

            return _cachedTransform;
        }
    }
}