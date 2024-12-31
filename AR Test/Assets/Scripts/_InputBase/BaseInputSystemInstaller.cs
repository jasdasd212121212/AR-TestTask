using Zenject;

public abstract class BaseInputSystemInstaller<InputSystem> : MonoInstaller where InputSystem : IInputSystem
{
    public override void InstallBindings()
    {
        Container?.Bind<InputSystem>().FromInstance(GetInputSystem()).AsSingle().NonLazy();
    }

    protected abstract InputSystem GetInputSystem();
}