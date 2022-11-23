using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DynamicEnemy : MonoBehaviour
{
    
    public float health;
//  Time a player gets for killing enemy
    public float timeGain;
    
    public float minDist = 2f;
// The player
    Transform player;
    // Animator of the Enemy
    Animator animator;
    NavMeshAgent agent;
    // time for using the Timehandling mechanics
    TimeHandling time; 
    // Patroling
    Vector3 walkPoint;
    private bool walkPointSet = false;
    public float walkPointRange;
    float dist;
    // Attacking
    public float attackCooldown = 2.5f;
    // public float timeBetweenAttacks;
    bool alreadyAttacked = false;
    // For testing enemy will not move
    public bool dontMoveTest = false;
    private Rigidbody _rigidbody;
    
    //States
    public float sightRadius = 10f, attackRange;
    public bool playerInSightRange, playerInAttackRange, enemyDead;

    public GameObject canvas;
    public Animator anim;
    public Text locationName;
    private void Awake()
    {
        HelpVariables.enemies++;
        _rigidbody = GetComponent<Rigidbody>();
        time = FindObjectOfType<TimeHandling>();
        player = GameObject.Find("Barbarian").transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        enemyDead = false;
    }


    void Update()
    {
        
        //StartCoroutine(KillAllEnem());

        Freezeposition();
        if(health<=0 && !enemyDead){
            enemyDies();
            enemyDead = true;
        }
        
        if(!dontMoveTest){
            dist = Vector3.Distance(gameObject.transform.position, player.position);
            transform.LookAt(player);
        // if(dist<=sightRadius+4 && !(dist <= sightRadius)){
        //     Invoke("Taunt",1);
        //     Invoke("ResetTaunt",2.7f);
        // }
            if(dist<= sightRadius)
            {
                //StartCoroutine(taunt());
                if (dist > minDist)
                {

                    animator.SetBool("isRunning", true);
                    //animator.SetBool("isIdle", false);
                    animator.SetBool("isAttacking", alreadyAttacked);
                    ChasePlayer();

                }
                else
                {
            
                    animator.SetBool("isRunning", false);
                    //animator.SetBool("isIdle", true);
                    if (!alreadyAttacked)
                        StartCoroutine(enableAttackCD(attackCooldown));
                }
            }
        }

        Freezeposition();
    }
    // private void Taunt(){
    //         animator.SetBool("isTaunting", true);
    //         animator.SetBool("isIdle", false);
    // }
    // private void ResetTaunt(){
    //     animator.SetBool("isTaunting", false);
    //     animator.SetBool("isIdle", true);
    // }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet && !animator.GetBool("isIdle"))
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;

        // Walkpoint reached
    }
    private void SearchWalkPoint()
    {
        
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        walkPointSet = true;
    }
    // Setting the Destinaion for the enemy to the postition of the player
    private void ChasePlayer()
    {
        if(!animator.GetBool("isIdle") &&!(animator.GetBool("isTaunting")) )
        agent.SetDestination(player.position);
    }
    private void StopChasePlayer()
    {
        if(!animator.GetBool("isIdle") )
        agent.SetDestination(transform.position);
    }
    // Start Attacking and Cooldown Coroutine
    private void AttackPlayer()
    {
        alreadyAttacked = true;
            animator.SetBool("isAttacking", alreadyAttacked);
        // agent.SetDestination(transform.position);
        // transform.LookAt(player);

        // if (!alreadyAttacked)
        // {
            StartCoroutine(enableAttackCD(attackCooldown));
        // }
    }

// Used for Reset the Cooldown
    private void ResetAttack()
    {
        alreadyAttacked = false;
        animator.SetBool("isAttacking", alreadyAttacked);
    }

    // Used for the cooldown
    IEnumerator enableAttackCD(float attackCD)
    {
            //Attack
            yield return new WaitForSeconds(1f);
            alreadyAttacked = true;
           
            animator.SetBool("isAttacking", alreadyAttacked);
           
        yield return new WaitForSeconds(attackCD);
        
            ResetAttack();


    }

// Enemy gets hit
    public void getsHit(float damage){
        HelpVariables.doneNothing = 0;
        animator.SetBool("isHittet", true);
        health-=damage;
        StartCoroutine(setBackHit());
    }
    IEnumerator setBackHit()
    {
        
        yield return new WaitForSeconds(1f);
        
            animator.SetBool("isHittet", false);


    }
    
// Enemy Dies
    public void enemyDies(){
        time.playerGainsTime(timeGain);
        animator.Play("Base Layer.Death");
        HelpVariables.enemies--;
        // if (HelpVariables.enemies <= 0)
        // {
        //     GameObject ll = GameObject.Find("LevelLoader");
        //     ll.GetComponent<StageManager>().stageCleared();
        // }
    }

    IEnumerator KillAllEnem()
    {
        yield return new WaitForSeconds(6f);
        enemyDies();
    }
   
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    void Freezeposition()
    {
        if (alreadyAttacked)
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
            transform.position = transform.position;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
    }
    
}
