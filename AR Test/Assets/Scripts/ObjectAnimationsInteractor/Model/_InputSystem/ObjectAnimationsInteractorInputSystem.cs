using System;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectAnimationsInteractorInputSystem : BaseObjectInteractionInputSystem<AnimatebleObject>
{
    public event Action<ObjectAnimationsData> dataChanged;

    public ObjectAnimationsInteractorInputSystem(ARRaycastManager raycastManager, InteractivePanel panel, LayerMask objectInteractionMask) : base(raycastManager, panel, objectInteractionMask)
    {
    }

    protected override void OnInteract(AnimatebleObject obj)
    {
        if (obj != null)
        {
            dataChanged?.Invoke(obj.Data);
        }
    }
}