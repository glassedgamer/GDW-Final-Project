using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (playerHealth.currentHealth <= 0) 
        {
            SceneManager.LoadScene("DeathScreen");
        }
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

        if (collision.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
