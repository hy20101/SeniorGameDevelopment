using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public float projectileSpeed = 100f;
    public float timer = 5f;

    private void Start()
    {
        Invoke("TimeOutDestroy", timer);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject instProj = Instantiate(projectile, transform.position, Quaternion.identity) as GameObject;
            Rigidbody instProjRigidBody = instProj.GetComponent<Rigidbody>();
            instProjRigidBody.AddForce(Vector3.forward * projectileSpeed);
        }
    }

    void TimeOutDestroy()
    {
        Destroy(gameObject);
    }
}
