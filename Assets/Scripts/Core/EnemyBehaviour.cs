using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System;

public class EnemyBehaviour : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private NavMeshAgent navComponent;
    public bool IsAutoAttack;

    [SerializeField]
    private MeleeAttack _meleeAttack;

    // Start is called before the first frame update
    void Start()
    {
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        navComponent.speed = speed;
        target = GameObject.Find("Player").transform;
        IsAutoAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            navComponent.SetDestination(target.position);
            navComponent.acceleration = 40f;
            navComponent.stoppingDistance = 4f;
        }
        if (IsAutoAttack && _meleeAttack.inRangeDict != null)
        {
            _meleeAttack.StartCoroutine("Attack");
        }
    }
}
