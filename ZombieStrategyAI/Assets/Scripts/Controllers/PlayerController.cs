using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject followerPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Civilian"))
        {
            CiviliansSpawner.DestroyACivilian.Invoke(other.gameObject);
            FollowerController controller =
                Instantiate(followerPrefab, other.transform.position, other.transform.rotation).GetComponent<FollowerController>();
            controller.SetDestinationPosition(transform);
        }
    }
}
