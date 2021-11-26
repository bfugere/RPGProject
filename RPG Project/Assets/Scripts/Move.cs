using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] Transform target;

    Ray lastRay;

    // Cached References
    NavMeshAgent myNavMeshAgent;

    void Start()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            lastRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(lastRay.origin, lastRay.direction * 100);

        myNavMeshAgent.SetDestination(target.position);
    }
}
