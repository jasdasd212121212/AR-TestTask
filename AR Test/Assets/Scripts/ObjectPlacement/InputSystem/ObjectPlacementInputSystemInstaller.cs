using UnityEngine.XR.ARFoundation;
using Zenject;

public class ObjectPlacementInputSystemInstaller : BaseInputSystemInstaller<ObjectPlacementInputSystem>
{
    [Inject] private ARRaycastManager _raycastManager;
    [Inject] private InteractivePanel _interactivePanel;

    protected override ObjectPlacementInputSystem GetInputSystem()
    {
        return new ObjectPlacementInputSystem(_raycastManager, _interactivePanel);
    }
}