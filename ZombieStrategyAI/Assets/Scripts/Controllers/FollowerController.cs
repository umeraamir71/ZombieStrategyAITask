using UnityEngine;
using UnityEngine.AI;

public class FollowerController : MonoBehaviour
{
    private Animator _animator;
    private NavMeshAgent _agent;

    private Vector3 _transformOffset;
    private Transform _playerTransform;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _agent.destination = _playerTransform.position - _playerTransform.forward * 2 + _transformOffset;

        bool isRunning = true;
        // Check if we've reached the destination
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    isRunning = false;
                }
            }
        }
        _animator.SetBool("running", isRunning);
    }

    public void SetDestinationPosition(Transform _transform)
    {
        _playerTransform = _transform;
        _transformOffset = Random.insideUnitSphere * 2f;
        _transformOffset.y = _transform.position.y;
    }
}
