using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerMovement))]

public class AnimEnemy : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovement _movement;
    private GameObject _player;

    public class Params
    {
        public static readonly int RunUp = Animator.StringToHash(nameof(RunUp));
        public static readonly int RunDown = Animator.StringToHash(nameof(RunDown));
        public static readonly int RunLeft = Animator.StringToHash(nameof(RunLeft));
        public static readonly int RunRigth = Animator.StringToHash(nameof(RunRigth));
    }

    private void Start()
    {
        _player = GameObject.Find("Player");
        _movement = GetComponent<PlayerMovement>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        SetupAnimation();
    }

    private void SetupAnimation()
    {
        if (transform.position.x < _player.transform.position.x)
        {
            _animator.SetBool(AnimEnemy.Params.RunRigth, _movement.RunRigth);
        }

        if (transform.position.x > _player.transform.position.x)
        {
            _animator.SetBool(AnimEnemy.Params.RunLeft, _movement.RunLeft);
        }

        if (transform.position.y < _player.transform.position.y)
        {
            _animator.SetBool(AnimEnemy.Params.RunDown, _movement.RunDown);
        }

        if (transform.position.y > _player.transform.position.y)
        {
            _animator.SetBool(AnimEnemy.Params.RunUp, _movement.RunUp);
        }
    }
}