using UnityEngine;
using UnityEngine.XR.ARFoundation;
using Zenject;

public class RaycastManagerInstaller : MonoInstaller
{
    [SerializeField] private ARRaycastManager _raycastManager;

    public override void InstallBindings()
    {
        Container.Bind<ARRaycastManager>().FromInstance(_raycastManager).AsSingle().Lazy();
    }
}