using UnityEngine;

public class AnimatebleObject : BaseInteractebleObject
{
    [SerializeField] private Animator _animator;

    [Space]

    [SerializeField] private AnimationClip[] _clips;

    public ObjectAnimationsData Data => new ObjectAnimationsData(_clips);

    public void StartAnimation(AnimationClip clip)
    {
        _animator.Play(clip.name, 0);
    }
}