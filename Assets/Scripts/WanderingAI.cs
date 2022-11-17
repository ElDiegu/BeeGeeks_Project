using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    [SerializeField] private float _wanderRadius;
    [SerializeField] private float _wanderTimer;
    [SerializeField] private float _targetRadius;
    [SerializeField] private GameObject _target;
    [SerializeField] private Canvas _exclamation;

    private bool _beeSpotted = false;
    private NavMeshAgent _agent;
    private float _timer;
    private bool _paralized = false;

    // Use this for initialization
    void OnEnable()
    {
        _agent = GetComponent<NavMeshAgent>();
        _timer = _wanderTimer;
        _exclamation.gameObject.SetActive(false);

        _target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (!_paralized)
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
                _agent.SetDestination(_target.transform.position);
            }
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

    public void Touched()
    {
        gameObject.layer = LayerMask.NameToLayer("Default");
        _paralized = true;
        StartCoroutine(Deparalize());
    }

    IEnumerator Deparalize()
    {
        yield return new WaitForSeconds(2);
        _paralized = false;
        gameObject.layer = LayerMask.NameToLayer("Enemy");
    }
}
