using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Specific behavior for the Slime Enemy
/// </summary>
public class SlimeBehavior : BaseEnemyBehavior {
    public Transform goal;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void Update()
    {
        agent.destination = goal.position;
    }
}
