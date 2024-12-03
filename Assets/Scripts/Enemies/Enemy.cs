using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    public int lives = 3;

    public float distThreshold = 10f;

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

        if(playerDist < distThreshold)
        {
            agent.enabled = true;
            agent.SetDestination(player.transform.position);
        } 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "pBullet") 
        { 
            Destroy(collision.gameObject);
            lives--;

            if (lives == 0) {
                Destroy(this.gameObject);
            }
        } 
        if (collision.gameObject.tag == "Sword")
        {
            print("Sword");
            
            Destroy(this.gameObject);
        }
    }
}
