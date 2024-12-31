using Zenject;

public class EventBusInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        EventBus eventBus = new EventBus();

        Container.Bind<EventBus>().FromInstance(eventBus).AsSingle().NonLazy();
    }
}