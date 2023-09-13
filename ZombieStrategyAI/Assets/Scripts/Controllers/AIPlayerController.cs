using UnityEngine;
using UnityEngine.AI;

public class AIPlayerController : MonoBehaviour
{
    [SerializeField] private CiviliansSpawner spawner;

    private NavMeshAgent _agent;
    private Transform _civilianToFollow;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void GetCivilianToFollow()
    {
        _civilianToFollow = spawner.GetRandomCivilian;
    }

    private void Update()
    {
        if (_civilianToFollow == null)
        {
            GetCivilianToFollow();
        }

        _agent.destination = _civilianToFollow.position;
    }
}
