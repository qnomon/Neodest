using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Calango_Move : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]GameObject player;
    public float PlayerDistance = 2.0f;
    private Animator animator;
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distance: " + distance);

        if(distance > PlayerDistance){
            
            animator.SetBool("Moving", true);
            Vector3 dirToPlayer = player.transform.position - transform.position;
            Vector3 newPos = transform.position + dirToPlayer;
             _agent.SetDestination(newPos);
        }
        else if(distance < 0.3f){
            animator.SetBool("Moving", false);
        }
    }
}
