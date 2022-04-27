using System.Collections;
using UnityEngine;

public class CommonPhysicsMovement : IMovable
{
    private Rigidbody2D _rigidbody;
    private float _moveForce;
    private float _maxSpeed;

    public CommonPhysicsMovement(Rigidbody2D rigidbody, float moveForce, float maxSpeed)
    {
        _rigidbody = rigidbody;

        if (_rigidbody == null)
            Debug.LogError(new System.ArgumentNullException(nameof(rigidbody)));

        _moveForce = moveForce;
        _maxSpeed = maxSpeed;
    }

    public IEnumerator Move()
    {
        while (_rigidbody != null)
        {
            if (_rigidbody == null)
                break;

            if (_rigidbody.velocity.magnitude < _maxSpeed)
                _rigidbody.AddForce(Vector2.right * _moveForce, ForceMode2D.Force);

            yield return null;
        }
    }
}
