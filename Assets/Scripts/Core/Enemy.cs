using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;
    public Transform target;
    private NavMeshAgent navComponent;

    // Start is called before the first frame update
    void Start()
    {
        navComponent = this.gameObject.GetComponent<NavMeshAgent>();
        navComponent.speed = speed;
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
    }
}
