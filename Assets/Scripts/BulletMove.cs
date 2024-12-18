using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    GameObject player;

    public float distanceFromPlayer = 10f;
    public float speed = 40f;

    public GameObject longRangeHitParticles;
    public GameObject shortRangeHitParticles;

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

        if(collision.gameObject.tag == "Long-Range") 
        {
            Instantiate(longRangeHitParticles, this.transform.position, this.transform.rotation);
        } else if(collision.gameObject.tag == "Short-Range") 
        {
            Instantiate(shortRangeHitParticles, this.transform.position, this.transform.rotation);
        }

        Destroy(this.gameObject);
    }


}
