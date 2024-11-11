using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent navMeshAgent;
    [SerializeField] Transform target; //giving Enemy the target
    [SerializeField] float chaseRange = 10f; //only attack if within 10 units
    float distanceToTarget = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceToTarget = Vector3.Distance(target.position, transform.position);
            if(distanceToTarget > navMeshAgent.stoppingDistance){
            GetComponent<Animator>().SetBool("attackParam", false);
            GetComponent<Animator>().SetTrigger("moveParam"); 
            navMeshAgent.SetDestination(target.position);
        }

        if(distanceToTarget <= navMeshAgent.stoppingDistance) {
            GetComponent<Animator>().SetBool("attackParam", true);
        }
        
        
        
        
        /* if(distanceToTarget <= chaseRange) {
            //Debug.Log("working");
            navMeshAgent.SetDestination(target.position);
        } */
    }
}
