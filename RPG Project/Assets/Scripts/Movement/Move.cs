using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    // Cached References
    NavMeshAgent myNavMeshAgent;
    Animator animator;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
            MoveToCursor();

        UpdateAnimator();
    }

    void MoveToCursor()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool hasHit = Physics.Raycast(ray, out RaycastHit hitInfo);

        if (hasHit)
            myNavMeshAgent.SetDestination(hitInfo.point);
    }

    void UpdateAnimator()
    {
        Vector3 velocity = myNavMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;

        animator.SetFloat("forwardSpeed", speed);
    }
}
