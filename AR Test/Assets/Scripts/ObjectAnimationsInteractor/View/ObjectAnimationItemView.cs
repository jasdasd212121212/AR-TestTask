using TMPro;
using UnityEngine;

public class ObjectAnimationItemView : BaseSelectableItemView
    <
        ObjectAnimationsModel,
        ObjectAnimationsInteractorInputSystem,
        AnimatebleObject,
        ObjectAnimationsData
    >
{
    [SerializeField] private TextMeshProUGUI _text;

    protected override void OnInitialize()
    {
        _text.text = Model.Data.Clips[Index].name;
    }

    protected override void OnClick()
    {
        Model.StartAnimation(Index);
    }
}