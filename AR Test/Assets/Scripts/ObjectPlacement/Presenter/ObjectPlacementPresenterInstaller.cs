using Zenject;

public class ObjectPlacementPresenterInstaller : MonoInstaller
{
    [Inject] private GameSettings _gameSettings;
    [Inject] private PlacebleObjectsHolder _objectsHolder;
    [Inject] private ObjectPlacementInputSystem _inputSystem;
    [Inject] private ObjectPlacementModel _model;

    public override void InstallBindings()
    {
        Container.Bind<ObjectPlacementPresenter>().FromInstance(new ObjectPlacementPresenter(
                _objectsHolder,
                _model,
                _gameSettings.ObjectMask
            )).AsSingle().NonLazy();

        Container.Bind<ObjectPlacementSpawnPresenter>().FromInstance(new ObjectPlacementSpawnPresenter(_model, _inputSystem)).AsSingle().NonLazy();
    }
}