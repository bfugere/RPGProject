using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Combat;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour
    {
        // Cached References
        NavMeshAgent myNavMeshAgent;
        Animator animator;
        Fighter fighter;
        ActionScheduler actionScheduler;

        void Start()
        {
            myNavMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            fighter = GetComponent<Fighter>();
            actionScheduler = GetComponent<ActionScheduler>();
        }

        void Update()
        {
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 destination)
        {
            actionScheduler.StartAction(this);
            fighter.Cancel();
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            myNavMeshAgent.SetDestination(destination);
            myNavMeshAgent.isStopped = false;
        }

        public void Stop()
        {
            myNavMeshAgent.isStopped = true;
        }

        void UpdateAnimator()
        {
            Vector3 velocity = myNavMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;

            animator.SetFloat("forwardSpeed", speed);
        }
    }
}
