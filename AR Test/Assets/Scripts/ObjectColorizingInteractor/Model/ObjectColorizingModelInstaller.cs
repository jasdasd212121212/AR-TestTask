using UnityEngine;

public class ObjectColorizingModelInstaller : BaseInteractionModelInstaller<ObjectColorizingModel, ObjectColorizingInputSystem, ColorizableObject>
{
    [SerializeField] private ObjectColorizingPalette _palette;

    protected override ObjectColorizingModel GetModel(ObjectColorizingInputSystem inputSystem, EventBus eventBus)
    {
        return new ObjectColorizingModel(inputSystem, _palette, eventBus);
    }
}