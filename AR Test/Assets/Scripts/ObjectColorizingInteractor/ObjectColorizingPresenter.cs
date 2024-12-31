using UnityEngine;

public class ObjectColorizingPresenter : BaseSelectablePresenter
    <
        ObjectColorizingModel,
        ObjectColorizingInputSystem,
        ColorizableObject,
        ObjectColorizingPalette
    >
{
    protected override void OnConstruct()
    {
        Model.colorized += OnColorize;        
    }

    private void OnDestroy()
    {
        Model.colorized -= OnColorize;
    }

    private void OnColorize(ColorizableObject target, Color color)
    {
        target.SetColor(color);
    }
}