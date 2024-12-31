using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ObjectAnimationsInteractorInputSystemInstaller : BaseObjectInteractionInstaller<AnimatebleObject, ObjectAnimationsInteractorInputSystem>
{
    protected override ObjectAnimationsInteractorInputSystem GetObjectInteractor(ARRaycastManager raycastManager, InteractivePanel interactivePanel, LayerMask objectInteractionMask)
    {
        return new ObjectAnimationsInteractorInputSystem(raycastManager, interactivePanel, objectInteractionMask);
    }
}