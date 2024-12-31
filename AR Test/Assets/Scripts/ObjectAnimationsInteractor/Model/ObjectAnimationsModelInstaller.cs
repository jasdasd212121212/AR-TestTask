public class ObjectAnimationsModelInstaller : BaseInteractionModelInstaller<ObjectAnimationsModel, ObjectAnimationsInteractorInputSystem, AnimatebleObject>
{
    protected override ObjectAnimationsModel GetModel(ObjectAnimationsInteractorInputSystem inputSystem, EventBus eventBus)
    {
        return new ObjectAnimationsModel(inputSystem, null, eventBus);
    }
}