using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NavMeshAgent = UnityEngine.AI.NavMeshAgent;
using NavMesh = UnityEngine.AI.NavMesh;
using NavMeshHit = UnityEngine.AI.NavMeshHit;
public class EnemyLocomotion : MonoBehaviour
{
    public GameObject target;
    public float maxDistance = 50;
    public float awarnessDistance;
    public float viewAngle = 70f;
    public Vector3 offset;
    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    private RaycastHit hit;
    
    private NavMeshAgent agent;
    public float speed = 4;
    public float keepDistance = 0.1f;
    public float minWanderDistance = 5;
    public float maxWanderDistance = 20;
    public bool repeat = true;
    private Animator animator;
    private Action targetHasBeenSeen;
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float timeBetweenAttacks=  1;
    bool alreadyAttacked;
    protected string info
    {
        get { return "Can See " + target; }
    }

    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        targetHasBeenSeen += () => OnCheck();
    }
    
    private void Update()
    {
        OnCheck();
        DoWander();
        onMove();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();

    } 
    
    void onMove()
    {
        animator.SetBool("isMoving", agent.velocity.magnitude > 0.1f );
    }
    
    private bool OnCheck()
    {
        playerInAttackRange = Vector3.Distance(transform.position, target.transform.position) < awarnessDistance;
        var targetTransform = target.transform;
        if (Vector3.Distance(transform.position, targetTransform.position) > maxDistance) return false;
        if (Physics.Linecast(transform.position + offset, targetTransform.position + offset, out hit))
        {
            if (hit.collider != targetTransform.GetComponent<Collider>())
            {
                playerInSightRange = false;
                return false;
            }
        }
        if (Vector3.Angle(targetTransform.position - transform.position, targetTransform.forward) < viewAngle) return true;
        if (Vector3.Distance(transform.position, targetTransform.position) < awarnessDistance) return true;
        return false;
        }

    void DoWander() {
        var min = minWanderDistance;
        var max = maxWanderDistance;
        min = Mathf.Clamp(min, 0.01f, max);
        max = Mathf.Clamp(max, min, max);
        var wanderPos = transform.position;
        while ( ( wanderPos - transform.position ).sqrMagnitude < ( min * min ) ) 
        { 
            wanderPos = ( UnityEngine.Random.insideUnitSphere * max ) + transform.position;
        }
        NavMeshHit hit;
        if ( NavMesh.SamplePosition(wanderPos, out hit, agent.height * 2, NavMesh.AllAreas) ) 
        { 
            agent.SetDestination(hit.position);
        }
    }
    private void ChasePlayer()
    {
        agent.SetDestination(target.transform.position);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);
        transform.LookAt(target.transform.position);

        if (!alreadyAttacked)
        {
            animator.SetBool("isAttacking", true);
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("isAttacking", false);
    }
    void OnDrawGizmosSelected()
    {
        if (this != null)
        {
            Gizmos.DrawLine(transform.position, target.transform.position + offset);
            Gizmos.DrawLine(transform.position + offset,
                transform.position + offset + (transform.right * maxDistance));
            Gizmos.DrawWireSphere(transform.position + offset + (transform.right * maxDistance), 0.1f);
            Gizmos.DrawWireSphere(transform.position, awarnessDistance);
            Gizmos.matrix = Matrix4x4.TRS(transform.position + offset, transform.rotation, Vector3.one);
            Gizmos.DrawFrustum(Vector3.zero, viewAngle, 5, 0, 1f);
        }
    }
}

