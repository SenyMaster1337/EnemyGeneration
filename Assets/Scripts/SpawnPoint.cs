using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Human _target;

    public Human Target => _target;
}
