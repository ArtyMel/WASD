using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : MonoBehaviour
{
    public List<Transform> patrolPoints;
    public PlayerController player;
    public float viewAngle;
    private NavMeshAgent _navMeshAgent;
    private bool _isPlayrerNoticed;
    public float damage;
    private PlayerHealf playerHealf;
    
    private void IntComponentLincs()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        playerHealf = player.GetComponent<PlayerHealf>();
    }
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    void Start()
    {
        IntComponentLincs();
        PickNewPatrolPoint();
    }
    private void PatrolUpdate()
    {
        if (!_isPlayrerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
    }
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayrerNoticed = false;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayrerNoticed = true;
                }
            }
        }
    }
    private void ChaseUpdate()
    {
        if (_isPlayrerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
            AttackUpdate();
        }
    }
 
    private void AttackUpdate()
    {
        if (_isPlayrerNoticed)
        {
            if(_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                Debug.Log("попал");
                playerHealf.DealDamage(damage * Time.deltaTime);
            }
        }
    }


    void Update()
    {
        NoticePlayerUpdate();

        ChaseUpdate();

        PatrolUpdate();
    }
}
