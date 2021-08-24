using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    AgroDetection aggro;
    Animator anim;
    Transform enemyTarget;
    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        aggro = GetComponent<AgroDetection>();
        aggro.OnAggro += Aggro_OnAggro;
    }

    private void Aggro_OnAggro(Transform target)
    {
        this.enemyTarget = target;
       
    }
    private void Update()
    {
        if (enemyTarget != null)
        {
            navMeshAgent.SetDestination(enemyTarget.position);
            float enemyCurrentSpeed = navMeshAgent.velocity.magnitude;
            anim.SetFloat("Speed", enemyCurrentSpeed);
        }
        
    }
}
