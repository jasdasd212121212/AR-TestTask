using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectColorizingInputSystem : BaseObjectInteractionInputSystem<ColorizableObject>
{
    public ObjectColorizingInputSystem(ARRaycastManager raycastManager, InteractivePanel panel, LayerMask objectInteractionMask) : base(raycastManager, panel, objectInteractionMask)
    {
    }
}