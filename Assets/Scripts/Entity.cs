using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    private IMovable _movable;
    private IJumpable _jumpable;
    private Coroutine _movableC;
    private Coroutine _jumpableC;

    public void SetMovement(IMovable movable)
    {
        _movable = movable;
    }

    public void ExecuteMovement()
    {
        if (_movableC != null)
        {
            StopCoroutine(_movableC);
        }

        _movableC = StartCoroutine(_movable.Move());
    }

    public void SetJumpBehaviour(IJumpable jumpable)
    {
        _jumpable = jumpable;
    }

    public void ExecuteJumpBehaviour()
    {
        if (_jumpableC != null)
        {
            StopCoroutine(_jumpableC);
        }

        _jumpableC = StartCoroutine(_jumpable.Jump());
    }

    public abstract void OnStart();

    public abstract void InitializeBehaviours();
}
