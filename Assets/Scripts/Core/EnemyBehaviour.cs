using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    AnimatorControlTest animator;

    public float speed = 5f;
    public Transform target;
    public bool IsAutoAttack;
    public float detectionRange;
    public float wanderRadius;
    
    private NavMeshAgent navComponent;
    private HealthSystem hpSystem;

    [SerializeField]
    private MeleeAttack _meleeAttack = null;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<AnimatorControlTest>();
        hpSystem = GetComponent<HealthSystem>();

        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        navComponent.speed = speed;
        wanderRadius = 7f;
        //target = GameObject.Find("Player").transform;
        IsAutoAttack = false;
        detectionRange = 20f;
    }

    // Update is called once per frame
    void Update()
    {
        moveToAttack();

        if (hpSystem.isAlive == false)
        {
            speed = 0;
            detectionRange = 0;
        }
    }

    void moveToAttack()
    {
        target = GameObject.FindWithTag("Player").transform;
        if (Vector3.Distance(target.position, transform.position) <= detectionRange)
        {
            navComponent.SetDestination(target.position);
            navComponent.acceleration = 20f;
            navComponent.stoppingDistance = 2f;

            animator.animator.SetFloat("MoveSpeed", navComponent.acceleration);

            if (Vector3.Distance(target.position, transform.position) <= navComponent.stoppingDistance)
            {
                IsAutoAttack = true;
            }
            else
            {
                IsAutoAttack = false;
            }

            if (IsAutoAttack)
            {
                _meleeAttack.StartCoroutine("Attack");
            }
        }
    }
}
