using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    GameObject player;

    public float distanceFromPlayer = 10f;
    public float speed = 40f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Vector3.Distance(player.transform.position, transform.position) > distanceFromPlayer)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("I hit " + collision.gameObject.name);
        Destroy(this.gameObject);
    }


}
