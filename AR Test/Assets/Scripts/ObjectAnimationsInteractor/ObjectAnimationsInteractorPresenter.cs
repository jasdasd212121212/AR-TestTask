using UnityEngine;

public class ObjectAnimationsInteractorPresenter : BaseSelectablePresenter
    <
        ObjectAnimationsModel,
        ObjectAnimationsInteractorInputSystem,
        AnimatebleObject,
        ObjectAnimationsData
    >
{
    protected override void OnConstruct()
    {
        Model.animationStarted += OnAimate;
    }

    private void OnDestroy()
    {
        Model.animationStarted -= OnAimate;
    }

    protected void OnAimate(AnimatebleObject obj, AnimationClip clip)
    {
        obj.StartAnimation(clip);
    }
}