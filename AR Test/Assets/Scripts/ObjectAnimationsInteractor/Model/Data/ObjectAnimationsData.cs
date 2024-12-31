using UnityEngine;

public class ObjectAnimationsData
{
    public AnimationClip[] Clips { get; private set; }

    public ObjectAnimationsData(AnimationClip[] clips)
    {
        Clips = clips;
    }
}