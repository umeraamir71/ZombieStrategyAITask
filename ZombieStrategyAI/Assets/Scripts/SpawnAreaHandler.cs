using UnityEngine;

public class SpawnAreaHandler : MonoBehaviour
{
    private BoxCollider _collider;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    public Vector3 GetSpawnPoint()
    {
        Vector3 _point = RandomPointInCollider();

        if (Physics.Raycast(_point, Vector3.down, out RaycastHit hit, Mathf.Infinity))
        {
            Debug.DrawRay(_point, Vector3.down * hit.distance, Color.yellow);
            return hit.point;
        }

        return Vector3.zero;
    }

    private Vector3 RandomPointInCollider()
    {
        return new Vector3(
            Random.Range(_collider.bounds.min.x, _collider.bounds.max.x),
            _collider.bounds.max.y,
            Random.Range(_collider.bounds.min.z, _collider.bounds.max.z)
        );
    }
}
