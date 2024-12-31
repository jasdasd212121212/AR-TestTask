using UnityEngine;
using Zenject;

public class ObjectPlacementModelInstaller : MonoInstaller
{
    [SerializeField] private PlacebleObjectsHolder _objectsHolder;

    public override void InstallBindings()
    {
        Container.Bind<PlacebleObjectsHolder>().FromInstance(_objectsHolder).AsSingle().Lazy();
        Container.Bind<ObjectPlacementModel>().FromInstance(new ObjectPlacementModel(_objectsHolder.Prefabs.Length)).AsSingle().NonLazy();
    }
}