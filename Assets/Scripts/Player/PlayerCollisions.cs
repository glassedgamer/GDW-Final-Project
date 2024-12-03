using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        { 
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(10);
        }

        if (collision.gameObject.tag == "eBullet")
        {
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(5);
        }
    }
}
