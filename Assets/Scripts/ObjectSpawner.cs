using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject projectile;
    public float delay = 3;

    Rigidbody rb;
    [SerializeField] float speed = 1;
    
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(projectile, transform) as GameObject;
            //rb = fireball.GetComponent<Rigidbody>();
            rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20 * Time.deltaTime;
            //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed * Time.deltaTime);

            Destroy(bullet, delay);
        }
    }
}
