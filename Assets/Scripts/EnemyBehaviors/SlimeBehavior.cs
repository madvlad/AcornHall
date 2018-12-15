using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Specific behavior for the Slime Enemy
/// </summary>
public class SlimeBehavior : BaseEnemyBehavior {
    public Transform playerTransform;
    public Transform home;

    private NavMeshAgent agent;
    private float defaultSpeed;
    private bool goingHome = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;
    }

    void Update()
    {
        float dist = Vector3.Distance(playerTransform.position, transform.position);

        if (!goingHome)
        {
            // Approach and attack the player if they are within 5 units, otherwise go home but not urgently
            if (dist < 5.0f)
            {
                agent.SetDestination(playerTransform.position);
            }
            else
            {
                agent.SetDestination(home.position);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, home.position) < 0.5f)
            {
                goingHome = false;
                agent.speed = defaultSpeed;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var other = collision.gameObject;

        // We hit the player, so return home urgently to rest
        if (other.CompareTag("Player"))
        {
            goingHome = true;
            agent.SetDestination(home.position);
        }
    }

    void OnPlayerHit()
    {
        // The player hit us? I'm a coward and am going to run home!
        goingHome = true;
        agent.speed *= 2;
        agent.SetDestination(home.position);
    }
}
