public class ObjectDraggingModelInstaller : BaseInteractionModelInstaller<ObjectDraggingModel, ObjectDragInteractionInputSystem, DraggebleObject>
{
    protected override ObjectDraggingModel GetModel(ObjectDragInteractionInputSystem inputSystem, EventBus eventBus)
    {
        return new ObjectDraggingModel(inputSystem);
    }
}