using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectDragInteractionInputSystemInstaller : BaseObjectInteractionInstaller<DraggebleObject, ObjectDragInteractionInputSystem>
{
    protected override ObjectDragInteractionInputSystem GetObjectInteractor(ARRaycastManager raycastManager, InteractivePanel interactivePanel, LayerMask objectInteractionMask)
    {
        return new ObjectDragInteractionInputSystem(raycastManager, interactivePanel, objectInteractionMask);
    }
}