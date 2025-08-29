using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _movementDirection;

    public void Init(Vector3 movementDirection)
    {
        _movementDirection = movementDirection;
    }

    private void FixedUpdate()
    {
        transform.Translate(_movementDirection);
    }
}
