using System;
using UnityEngine;

public class ObjectColorizingModel : BaseSelectableModel<ObjectColorizingInputSystem, ColorizableObject, ObjectColorizingPalette>
{
    private Color _currentColor;

    public event Action<ColorizableObject, Color> colorized;

    public ObjectColorizingModel(ObjectColorizingInputSystem inputSystem, ObjectColorizingPalette data, EventBus eventBus) : base(inputSystem, data, eventBus)
    {
        _currentColor = Data.Colors[0];
    }

    public void SetColorByIndex(int index)
    {
        if (index < 0 || index >= Data.Colors.Length)
        {
            Debug.LogError($"Error -> invalid color index: {index} (BOUNDS: 0, {Data.Colors.Length - 1}); In result -> Clamped");
        }

        index = Mathf.Clamp(index, 0, Data.Colors.Length - 1);
        _currentColor = Data.Colors[index];
    }

    public void ColorizeCurrentObject()
    {
        if (CurrentObject != null)
        {
            colorized?.Invoke(CurrentObject, _currentColor);
        }
    }
}