using UnityEngine;
using Zenject;

public class InteractivePanelInstaller : MonoInstaller
{
    [SerializeField] private InteractivePanel _panel;

    public override void InstallBindings()
    {
        Container.Bind<InteractivePanel>().FromInstance(_panel).AsSingle().Lazy();
    }
}