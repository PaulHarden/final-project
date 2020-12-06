using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    RaycastHit enemyRay;
    public float detectDistance;

    void Update()
    {
        Wander();

        //CASTING DETECTION SPHERE AROUND ENEMY
        Collider[] detectedObjects = Physics.OverlapSphere(transform.position, detectDistance);
        foreach(var hitCollider in detectedObjects)
        {
            //DETECTING THE PLAYER WHEN CLOSE ENOUGH
            if(hitCollider.gameObject.name == "Player Character")
            {
                //RAYCAST CHECK BACK TO ENEMY AND MOVE
                if(Physics.Raycast(transform.position, (hitCollider.gameObject.transform.position - transform.position), out enemyRay, detectDistance))
                {
                    agent.SetDestination(player.transform.position);
                }
            }
        }
    }

    void Wander()
    {
        if(!agent.pathPending && !agent.hasPath)
        {
            if(Random.Range(0, 500) == 1)
            {
                var destinationOffset = new Vector3(Random.Range(1, 10), 0, Random.Range(1, 10));
                var randomDestination = transform.position + destinationOffset;
                agent.SetDestination(randomDestination);
            }
        }
    }
}
