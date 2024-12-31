using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectColorizingInputSystemInstaller : BaseObjectInteractionInstaller<ColorizableObject, ObjectColorizingInputSystem>
{
    protected override ObjectColorizingInputSystem GetObjectInteractor(ARRaycastManager raycastManager, InteractivePanel interactivePanel, LayerMask objectInteractionMask)
    {
        return new ObjectColorizingInputSystem(raycastManager, interactivePanel, objectInteractionMask);
    }
}