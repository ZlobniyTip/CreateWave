using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]

public class AnimPlayer : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;

    public class Params
    {
        public static readonly int RunUp = Animator.StringToHash(nameof(RunUp));
        public static readonly int RunDown = Animator.StringToHash(nameof(RunDown));
        public static readonly int RunLeft = Animator.StringToHash(nameof(RunLeft));
        public static readonly int RunRigth = Animator.StringToHash(nameof(RunRigth));
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        SetupAnimation();
    }

    private void SetupAnimation()
    {
        _animator.SetBool(AnimPlayer.Params.RunUp, _movement.RunUp);
        _animator.SetBool(AnimPlayer.Params.RunDown, _movement.RunDown);
        _animator.SetBool(AnimPlayer.Params.RunLeft, _movement.RunLeft);
        _animator.SetBool(AnimPlayer.Params.RunRigth, _movement.RunRigth);
    }
}