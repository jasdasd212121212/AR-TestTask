using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Zenject;

public abstract class BaseObjectInteractionInstaller<TObject, TInputSystem> : BaseInputSystemInstaller<TInputSystem>
    where TObject : BaseInteractebleObject
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
{
    [Inject] private ARRaycastManager _raycastManager;
    [Inject] private InteractivePanel _interactivePanel;
    [Inject] private GameSettings _gameSettings;

    protected override TInputSystem GetInputSystem()
    {
        return GetObjectInteractor(_raycastManager, _interactivePanel, _gameSettings.ObjectMask);
    }

    protected abstract TInputSystem GetObjectInteractor(ARRaycastManager raycastManager, InteractivePanel interactivePanel, LayerMask objectInteractionMask);
}