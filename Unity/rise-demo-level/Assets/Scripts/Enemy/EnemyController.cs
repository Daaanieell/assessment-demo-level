using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform player;
    [SerializeField] private float detectionRange = 5f;
    [SerializeField] private float attackRange = 2f;
    [SerializeField] private List<Transform> patrolPoints;
    [SerializeField] private float BlindDuration = 5f;
    private bool blinded = false;
    private Transform currentPatrolPoint;
    private int currentIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // ----------- "do" methods -----------
    public void Chase()
    {
        // Debug.Log(gameObject.name + ": chasing..");
        var marginDirection = player.position - transform.position;
        var margin = -0.5f;
        agent.SetDestination(player.position + marginDirection * margin);
    }

    public void Patrol()
    {
        // Debug.Log(gameObject.name + ": patrolling..");
        if (patrolPoints.Count == 0) Debug.LogWarning(gameObject.name + "no patrol points");

        if (currentPatrolPoint == null) currentPatrolPoint = patrolPoints[currentIndex];

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 2f)
        {
            currentIndex++;
            if (currentIndex >= patrolPoints.Count) currentIndex = 0;
            currentPatrolPoint = patrolPoints[currentIndex];
        }

        agent.SetDestination(currentPatrolPoint.position);
    }

    public void Attack()
    {
        Debug.Log(gameObject.name + ": im attacking!!");
    }

    public void StandStill()
    {
        agent.SetDestination(transform.position);
    }

    // ----------- transition checks -----------

    public bool IsInChaseRange()
    {
        if (Vector3.Distance(transform.position, player.position) < detectionRange) return true;
        return false;
    }

    public bool IsInAttackRange()
    {
        if (Vector3.Distance(transform.position, player.position) < attackRange) return true;
        return false;
    }

    public bool IsBlinded()
    {
        return blinded;
    }

    // ----------- blind timer -----------w

    public void Blind()
    {
        Debug.Log(gameObject.name + ": im blinded!!");
        StartBlind();
    }

    // this is a timer, it allows for a minimum "blind" duration
    public void StartBlind()
    {
        if (!blinded)
        {
            StartCoroutine(EndBlind());
            blinded = true;
        }
    }

    private IEnumerator EndBlind()
    {
        yield return new WaitForSeconds(BlindDuration);
        blinded = false;
        // Debug.Log(gameObject.name + ": im no longer blinded!");
    }




}
