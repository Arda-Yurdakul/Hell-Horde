using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float aggroRange;
    [SerializeField] private float attackDistance;


    private bool aggressive;
    NavMeshAgent navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        aggressive = false;
    }

    // Update is called once per frame
    void Update()
    {
        BehaviorAI();
    }



    private void BehaviorAI()
    {
        if (aggressive)
            Engage();
        else if (Vector3.Distance(player.position, transform.position) < aggroRange)
            aggressive = true;

        
    }

    private void Engage()
    {
        if (Vector3.Distance(player.position, transform.position) > attackDistance)
            navMeshAgent.SetDestination(player.position);
        else
        {
            print("Take this!");
            navMeshAgent.ResetPath();
        }
            
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, aggroRange);
    }
}
