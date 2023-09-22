using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private bool _runUp;
    private bool _runDown;
    private bool _runLeft;
    private bool _runRigth;

    public bool RunUp => _runUp;
    public bool RunDown => _runDown;
    public bool RunLeft => _runLeft;
    public bool RunRigth => _runRigth;

    public float Speed => _speed;

    private void Update()
    {
        _runUp = false;
        _runDown = false;
        _runLeft = false;
        _runRigth = false;

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(_speed * Time.deltaTime, 0, 0);
            _runRigth = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
            _runLeft = true;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, _speed * Time.deltaTime, 0);
            _runUp = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, _speed * Time.deltaTime * -1, 0);
            _runDown = true;
        }
    }
}