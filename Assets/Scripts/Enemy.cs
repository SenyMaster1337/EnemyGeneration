using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    private Human _target;

    public void Init(Human target)
    {
        _target = target;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, _target.transform.position, _moveSpeed);
        transform.LookAt(_target.transform.position);
    }
}
