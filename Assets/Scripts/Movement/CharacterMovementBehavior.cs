using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementBehavior : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private Vector2 _mouseDirection;

    [SerializeField]
    private float _rotationSpeed;

    public Vector3 MoveDirection
    {
        get { return _moveDirection; }
        set { _moveDirection = value; }
    }

    public Vector2 MouseDirection
    {
        get { return _mouseDirection; }
        set { _mouseDirection = value; }
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 velocity = MoveDirection * _speed * Time.fixedDeltaTime;
        _rigidbody.MovePosition(transform.position + velocity);
    }
}
