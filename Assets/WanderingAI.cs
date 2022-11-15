using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] private float _wanderRadius;
    [SerializeField] private float _wanderTimer;
    [SerializeField] private float _targetRadius;
    [SerializeField] private Transform _target;
    [SerializeField] private Canvas _exclamation;

    private Camera _mainCamera;
    private bool _beeSpotted = false;
    private NavMeshAgent _agent;
    private float _timer;

    // Use this for initialization
    void OnEnable()
    {
        _mainCamera = FindObjectOfType<Camera>();
        _agent = GetComponent<NavMeshAgent>();
        _timer = _wanderTimer;
        _exclamation.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_beeSpotted)
        {
            float distance = Vector3.Distance(_target.transform.position, transform.position);

            _beeSpotted = distance <= _targetRadius;

            if (!_beeSpotted)
            {
                _timer += Time.deltaTime;

                if (_timer >= _wanderTimer)
                {
                    Vector3 newPos = RandomNavSphere(transform.position, _wanderRadius, -1);
                    _agent.SetDestination(newPos);
                    _timer = 0;
                }
            }
            else
            {
                _exclamation.gameObject.SetActive(true);
            }
        }
        else
        {
            _agent.SetDestination(_target.position);
            _exclamation.gameObject.transform.LookAt(_mainCamera.transform.position);
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}
