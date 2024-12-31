using Zenject;

public abstract class BaseInteractionModelInstaller<TModel, TInputSystem, TObject> : MonoInstaller
    where TModel : BaseInteractionModel<TInputSystem, TObject>
    where TObject : BaseInteractebleObject
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
{
    [Inject] private TInputSystem _inputSystem;
    [Inject] private EventBus _eventBus;

    public override void InstallBindings()
    {
        Container.Bind<TModel>().FromInstance(GetModel(_inputSystem, _eventBus)).AsSingle().NonLazy();
    }

    protected abstract TModel GetModel(TInputSystem inputSystem, EventBus eventBus);
}