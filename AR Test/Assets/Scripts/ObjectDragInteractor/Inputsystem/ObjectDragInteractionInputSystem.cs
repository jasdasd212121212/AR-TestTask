using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectDragInteractionInputSystem : BaseObjectInteractionInputSystem<DraggebleObject>
{
    public ObjectDragInteractionInputSystem(ARRaycastManager raycastManager, InteractivePanel panel, LayerMask objectInteractionMask) : base(raycastManager, panel, objectInteractionMask)
    {
    }
}