public abstract class BaseInteractionModel<TInputSystem, TObject> 
    where TInputSystem : BaseObjectInteractionInputSystem<TObject>
    where TObject : BaseInteractebleObject
{
    protected TInputSystem InputSystem { get; private set; }

    public BaseInteractionModel(TInputSystem inputSystem)
    {
        InputSystem = inputSystem;
    }
}