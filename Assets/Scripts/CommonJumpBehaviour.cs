using System.Collections;
using UnityEngine;

public class CommonJumpBehaviour : IJumpable
{
    private Rigidbody2D _rigidbody;
    private float _doubleJumpMaxWaiting;
    private float _jumpStrength;
    private bool _isOnCeiling;

    // сделать какой-то скрипт, который проверяет игрок в воздухе или нет, и передать его сюда, чтобы подписываться на его события

    public CommonJumpBehaviour(Rigidbody2D rigidbody, float doubleJumpMaxWaiting, float jumpStrength)
    {
        _rigidbody = rigidbody;

        if (rigidbody == null)
            Debug.LogError(new System.ArgumentNullException(nameof(rigidbody)));

        _doubleJumpMaxWaiting = doubleJumpMaxWaiting;
        _jumpStrength = jumpStrength;
    }

    public IEnumerator Jump()
    {
        while (_rigidbody != null)
        {
            if (DetectInput())
                DoJump();

            yield return null;
        }
    }

    private bool DetectInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            return true;

        return false;
    }

    private void DoJump()
    {
        _rigidbody.AddForce(Vector2.up * _jumpStrength, ForceMode2D.Impulse);
    }
}