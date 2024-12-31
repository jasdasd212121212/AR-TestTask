using UnityEngine;
using Zenject;

public class GameSettingsInstaller : MonoInstaller
{
    [SerializeField] private GameSettings _gameSettings;

    public override void InstallBindings()
    {
        Container.Bind<GameSettings>().FromInstance(_gameSettings).AsSingle().Lazy();
    }
}