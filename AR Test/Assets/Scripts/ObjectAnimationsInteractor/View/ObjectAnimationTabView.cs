using System;

public class ObjectAnimationTabView : BaseSelectableTabView
    <
        ObjectAnimationsModel,
        ObjectAnimationsInteractorInputSystem,
        AnimatebleObject,
        ObjectAnimationsData,
        ObjectAnimationItemView
    >
{
    protected override Array GetDataIterateble(ObjectAnimationsData data)
    {
        return data.Clips;
    }
}