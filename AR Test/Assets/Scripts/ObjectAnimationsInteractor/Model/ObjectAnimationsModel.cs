using System;
using UnityEngine;

public class ObjectAnimationsModel : BaseSelectableModel<ObjectAnimationsInteractorInputSystem, AnimatebleObject, ObjectAnimationsData>
{
    public event Action<AnimatebleObject, AnimationClip> animationStarted;

    public ObjectAnimationsModel(ObjectAnimationsInteractorInputSystem inputSystem, ObjectAnimationsData data, EventBus eventBus) : base(inputSystem, data, eventBus)
    {
        InputSystem.dataChanged += OnReceiveData;
    }

    ~ObjectAnimationsModel()
    {
        if (InputSystem != null)
        {  
            InputSystem.dataChanged -= OnReceiveData;
        }
    }

    private void OnReceiveData(ObjectAnimationsData data)
    {
        Data = data;
    }

    public void StartAnimation(int animationIndex)
    {
        if (Data == null)
        {
            Debug.LogError("Critical error -> can`t animate object without animation data");
            return;
        }

        if (animationIndex < 0 || animationIndex >= Data.Clips.Length)
        {
            Debug.LogError($"Error -> invalid animation index: {animationIndex} (BOUNDS: 0, {Data.Clips.Length - 1}); In result -> Clamped");
        }

        AnimationClip clip = Data.Clips[Mathf.Clamp(animationIndex, 0, Data.Clips.Length - 1)];
        animationStarted?.Invoke(CurrentObject, clip);
    }
}