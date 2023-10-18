using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FloatingJoystick _joystick;

    private Rigidbody _rigidbody;
    private Animator _animator;

    [SerializeField] private float _moveSpeed = 1f;

    private Vector3 cameraForward;
    private Vector3 cameraRight;
    // Start is called before the first frame update
    void Start()
    {
        _joystick = _joystick ?? GameObject.FindObjectOfType<FloatingJoystick>();
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            Vector2 joystickValues = Vector3.Normalize(new Vector2(_joystick.Horizontal, _joystick.Vertical));
            cameraForward = Vector3.Normalize(new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z));
            cameraRight = Vector3.Normalize(new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z));
            _rigidbody.velocity = (joystickValues.x * cameraRight + joystickValues.y * cameraForward) * _moveSpeed;
            transform.LookAt(transform.position + _rigidbody.velocity);
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
}
