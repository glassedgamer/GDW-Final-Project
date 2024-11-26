using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeEnemy : MonoBehaviour
{

    public float bulletSpeed = 1000f;
    [SerializeField] float timer = 5f;
    float bulletTime;

    public GameObject bulletPrefab;
    GameObject player;

    public Transform shootPoint;
    
    void Start()
    {
        player = player = GameObject.FindWithTag("Player");
	}

    
    void Update()
    {
		Vector3 playerPos = player.transform.position;
		Vector3 enemyPos = this.transform.position;

		float playerDist = Vector3.Distance(enemyPos, playerPos);

        if (playerDist <= 20) 
        {
		    transform.LookAt(player.transform.position);
            ShootAtPlayer();
        }
    }

    void ShootAtPlayer() 
    { 
        bulletTime -= Time.deltaTime;

        if (bulletTime > 0) return;

        bulletTime = timer;

        GameObject bulletClone = Instantiate(bulletPrefab, shootPoint.transform.position, shootPoint.transform.rotation) as GameObject;
        Rigidbody bulletRB = bulletClone.GetComponent<Rigidbody>();

        bulletRB.AddForce(bulletRB.transform.forward * bulletSpeed, ForceMode.Impulse);

        Destroy(bulletClone, 3f);
    }
}
