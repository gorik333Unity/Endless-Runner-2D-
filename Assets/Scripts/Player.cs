using UnityEngine;

public class Player : Entity
{
    [SerializeField]
    private Rigidbody2D _rigidbody;

    [SerializeField]
    private float _moveForce;

    [SerializeField]
    private float _maxSpeed;

    [SerializeField]
    private float _doubleJumpMaxWaiting;

    [SerializeField]
    private float _jumpStrength;

    public override void InitializeBehaviours()
    {
        SetMovement(new CommonPhysicsMovement(_rigidbody, _moveForce, _maxSpeed));
        SetJumpBehaviour(new CommonJumpBehaviour(_rigidbody, _doubleJumpMaxWaiting, _jumpStrength));
    }

    public override void OnStart()
    {
        ExecuteMovement();
        ExecuteJumpBehaviour();
    }

    private void Awake()
    {
        if (_rigidbody == null)
            _rigidbody.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        InitializeBehaviours();
        OnStart();
    }
}