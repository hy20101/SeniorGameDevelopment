using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    public bool IsAutoAttack;
    public float detectionRange;
    public float wanderRadius;
    
    private NavMeshAgent navComponent;
    private Vector3 wanderPoint;

    [SerializeField]
    private MeleeAttack _meleeAttack;

    // Start is called before the first frame update
    void Start()
    {
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        navComponent.speed = speed;
        wanderRadius = 7f;
        //target = GameObject.Find("Player").transform;
        IsAutoAttack = true;
        detectionRange = 20f;
        wanderPoint = RandomWanderPoint();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= detectionRange)
        {
            navComponent.SetDestination(target.position);
            navComponent.acceleration = 20f;
            navComponent.stoppingDistance = 3f;
        }
        else
        {
            Wander();
        }

        if (IsAutoAttack && _meleeAttack.inRangeDict != null)
        {
            _meleeAttack.StartCoroutine("Attack");
        }
    }

    void Wander()
    {
        if(Vector3.Distance(transform.position, wanderPoint) < 2f)
        {
            wanderPoint = RandomWanderPoint();
        }
        else
        {
            navComponent.SetDestination(wanderPoint);
        }
    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (UnityEngine.Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, navHit.position.y, navHit.position.z);
    }
}
