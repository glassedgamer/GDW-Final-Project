using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{

    PlayerHealth playerHealth;
    AudioManager am;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        am = FindObjectOfType<AudioManager>();
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
        if (collision.gameObject.tag == "Short-Range") 
        { 
            am.Play("Player Hit");
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(15);
        }

        if (collision.gameObject.tag == "eBullet")
        {
            am.Play("Player Hit");
            Destroy(collision.gameObject);
            playerHealth.TakeDamage(10);
        }

        if (collision.gameObject.tag == "Portal")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
}
