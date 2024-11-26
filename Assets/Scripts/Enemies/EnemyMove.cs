using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{

    GameObject player;

    public NavMeshAgent agent;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        Swarm();
    }

    void Swarm()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = this.transform.position;

        float playerDist = Vector3.Distance(enemyPos, playerPos);

        if(playerDist < 5f)
        {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
        } 
    }
}
