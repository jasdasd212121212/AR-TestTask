using System;

public class ObjectColorizingTabView : BaseSelectableTabView
    <
        ObjectColorizingModel,
        ObjectColorizingInputSystem,
        ColorizableObject,
        ObjectColorizingPalette,
        ObjectColorizingItemView
    >
{
    protected override Array GetDataIterateble(ObjectColorizingPalette data)
    {
        return data.Colors;
    }
}