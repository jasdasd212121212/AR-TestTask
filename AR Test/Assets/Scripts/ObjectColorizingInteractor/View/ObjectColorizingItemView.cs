using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ObjectColorizingItemView : BaseSelectableItemView
    <
        ObjectColorizingModel,
        ObjectColorizingInputSystem,
        ColorizableObject,
        ObjectColorizingPalette
    >
{
    [SerializeField] private Image _colorImage;

    private Color _selfColor;

    protected override void OnInitialize()
    {
        _selfColor = Data.Colors[Index];

        _colorImage.color = _selfColor;
    }

    protected override void OnClick()
    {
        Model.SetColorByIndex(Index);
        Model.ColorizeCurrentObject();
    }
}